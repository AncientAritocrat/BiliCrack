using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace BiLiCrack
{
    public partial class Form1 : Form
    {
        string VideoPath; //视频文件
        string AudioPath; //音频文件
        string outputFolder = "D:\\Videos\\BilibiliCrack\\CrackedVideo"; //上级保存路径
        string VideoInfoPath; //视频信息文件
        string Title;
        string GroupTitle;

        public Form1()
        {
            InitializeComponent();
        }

        //视频地址=》选文件大小较大的那个
        private void btnVideoChoose_Click(object sender, EventArgs e)
        {
            if (ofdVideo.ShowDialog() == DialogResult.OK)
            {
                tbVideo.Text = ofdVideo.FileName;
                VideoPath = ofdVideo.FileName;
            }
        }

        //音频地址=》选文件大小较小的那个
        private void btnAudioChoose_Click(object sender, EventArgs e)
        {
            if(ofdAudio.ShowDialog() == DialogResult.OK)
            {
                tbAudio.Text = ofdAudio.FileName;
                AudioPath = ofdAudio.FileName;
            }
        }

        //转化
        private void btnCrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbVideoInfo.Text.Trim()))
            {
                MessageBox.Show("请选择视频信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(VideoPath))
            {
                MessageBox.Show("请选择视频文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(AudioPath))
            {
                MessageBox.Show("请选择音频文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Directory.CreateDirectory(outputFolder); // 确保主文件夹存在
            string outputSubFolder = Path.Combine(outputFolder, GroupTitle);
            Directory.CreateDirectory(outputSubFolder); // 创建子文件夹

            string outputVideoPath = Path.Combine(outputSubFolder, Title + "_Video.m4s");
            string outputAudioPath = Path.Combine(outputSubFolder, Title + "_Audio.m4s");
            string outputPath = Path.Combine(outputSubFolder, Title + ".mp4");

            fix_m4s(VideoPath, outputVideoPath);
            fix_m4s(AudioPath, outputAudioPath);
            MergeAndConvertToMp4(outputVideoPath, outputAudioPath, outputPath);

            MessageBox.Show($"文件已保存至: {outputPath}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //M4S破解转换
        //函数参数targetPath是要破解的m4s文件路径，
        //outputPath是破解好的文件的输出路径，
        //bufsize是缓冲大小，默认256M，防止一次性读取太多出事故
        private void fix_m4s(string targetPath, string outputPath, int bufsize = 256 * 1024 * 1024)
        {
            if (bufsize <= 0)
                throw new ArgumentException("Buffer size must be greater than 0", nameof(bufsize));

            using (FileStream targetFile = new FileStream(targetPath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                byte[] header = new byte[32];
                int bytesRead = targetFile.Read(header, 0, header.Length);

                string headerStr = Encoding.ASCII.GetString(header, 0, bytesRead);
                //headerStr = headerStr.Replace("000000000", "")
                //                     .Replace("$", " ")
                //                     .Replace("avc1", "");
                headerStr = headerStr.Replace("000000000", "");
                byte[] newHeader = Encoding.ASCII.GetBytes(headerStr);
                outputFile.Write(newHeader, 0, newHeader.Length);

                byte[] buffer = new byte[bufsize];
                while ((bytesRead = targetFile.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputFile.Write(buffer, 0, bytesRead);
                }
            }
        }

        //M4S合并转化为MP4 
        public static void MergeAndConvertToMp4(string videoPath, string audioPath, string outputPath)
        {
            string arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c copy \"{outputPath}\"";
            FFmpegHelper.RunFFmpeg(arguments);
            // 删除视频和音频临时文件
            if (File.Exists(videoPath)) File.Delete(videoPath);
            if (File.Exists(audioPath)) File.Delete(audioPath);
        }

        private void btnAudioCrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbVideoInfo.Text.Trim()))
            {
                MessageBox.Show("请选择视频信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(AudioPath))
            {
                MessageBox.Show("请选择音频文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Directory.CreateDirectory(outputFolder); // 确保主文件夹存在
            string outputSubFolder = Path.Combine(outputFolder, GroupTitle);
            Directory.CreateDirectory(outputSubFolder); // 创建子文件夹

            string outputAudioPath = Path.Combine(outputSubFolder, Title + "_Audio.m4s");
            string outputPath = Path.Combine(outputSubFolder, Title + ".m4a");
            fix_m4s(AudioPath, outputAudioPath);

            string arguments = $"-i \"{outputAudioPath}\" -c copy \"{outputPath}\"";
            FFmpegHelper.RunFFmpeg(arguments);
            if (File.Exists(outputAudioPath)) File.Delete(outputAudioPath);

            MessageBox.Show($"文件已保存至: {outputPath}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //tbAudio.Text = string.Empty;
            //tbVideo.Text = string.Empty;
            tbAudio.Clear();
            tbVideo.Clear();
            tbVideoInfo.Clear();
            Name = string.Empty;
            AudioPath = string.Empty;
            VideoPath = string.Empty;
        }

        private void btnVideoInfo_Click(object sender, EventArgs e)
        {
            if (ofdVideoInfo.ShowDialog() == DialogResult.OK)
            {
                tbVideoInfo.Text = ofdVideoInfo.FileName;
                VideoInfoPath = ofdVideoInfo.FileName;
            }
            ReadViedoInfo(VideoInfoPath);
        }

        private void ReadViedoInfo(string VideoInfoPath)
        {
            //读取Json
            string jsonText = File.ReadAllText(VideoInfoPath);
            // 解析 JSON
            var jsonData = JsonConvert.DeserializeObject<Information>(jsonText);

            // 输出 "title" 和 "groupTitle"
            //Console.WriteLine($"Title: {jsonData?.Title}");
            //Console.WriteLine($"Group Title: {jsonData?.GroupTitle}");
             string Initial_Title = jsonData?.Title;
            string Initial_GroupTitle = jsonData?.GroupTitle;
            Title = Regex.Replace(Initial_Title, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]", "_");
            GroupTitle = Regex.Replace(Initial_GroupTitle, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]", "_");
        }

       
    }

}
