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
using Common;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace BiLiCrack
{
    public partial class Form2 : Form
    {
        //存储选择的文件夹
        string selectedPath; 
        
        //存储标题和专辑名
        string Title;   
        string GroupTitle;

        //上级保存路径
        string outputFolder = "D:\\Videos\\BilibiliCrack\\CrackedVideo"; 
        string[] m4sFiles;
        string jsonFile;

        // 存储窗体的初始宽度和高度
        private float originalFormWidth;
        private float originalFormHeight;

        // 存储每个控件的初始字体大小
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        public Form2()
        {
            InitializeComponent();
            AutoControlSize.RegisterFormControl(this);  //窗体大小调整时动态调整控件大小
        }

        //选择视频文件夹
        private void btnFolder_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true // 选择文件夹模式
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                selectedPath = dialog.FileName;

                // 获取 .m4s 和 .json 文件
                m4sFiles = Directory.GetFiles(selectedPath, "*.m4s", SearchOption.AllDirectories);
                jsonFile = Directory.GetFiles(selectedPath, "*.json", SearchOption.AllDirectories).FirstOrDefault();
                
                ReadViedoInfo(jsonFile);
                tbGroupTitle.Text = GroupTitle;
                tbTitle.Text = Title;
            }
            tbFolder.Text = selectedPath;

        }

        //破解视频
        private void btnCrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolder.Text.Trim()))
            {
                MessageBox.Show("请选择视频文件夹", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Directory.CreateDirectory(outputFolder); // 确保主文件夹存在
            string outputSubFolder = Path.Combine(outputFolder, GroupTitle);
            Directory.CreateDirectory(outputSubFolder); // 创建子文件夹

            //中间文件==》"_Video.m4s"和"_Audio.m4s"
            string outputVideoPath = Path.Combine(outputSubFolder, Title + "_Video.m4s");
            string outputAudioPath = Path.Combine(outputSubFolder, Title + "_Audio.m4s");
            //最终输出文件
            string outputPath = Path.Combine(outputSubFolder, Title + ".mp4");

            //根据文件大小获取视频文件和音频文件
            if (m4sFiles.Length > 0)
            {
                // 按文件大小排序
                var sortedFiles = m4sFiles.Select(file => new FileInfo(file))
                                          .OrderBy(f => f.Length)
                                          .ToList();

                string smallestFile = sortedFiles.First().FullName; //音频地址=》选文件大小较小的那个
                string largestFile = sortedFiles.Last().FullName;  //视频地址=》选文件大小较大的那个

                // 处理最小和最大的 m4s 文件
                fix_m4s(smallestFile, outputAudioPath);
                fix_m4s(largestFile, outputVideoPath);
            }
            else
            {
                MessageBox.Show("未找到 .m4s 文件", "错误");
            }
            MergeAndConvertToMp4(outputVideoPath, outputAudioPath, outputPath);

            MessageBox.Show($"文件已保存至: {outputPath}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //读取JSON文件
        private void ReadViedoInfo(string VideoInfoPath)
        {
            //读取Json
            string jsonText = File.ReadAllText(VideoInfoPath);
            // 解析 JSON
            var jsonData = JsonConvert.DeserializeObject<Information>(jsonText);

            // 输出 "title" 和 "groupTitle"
            string Initial_Title = jsonData?.Title;
            string Initial_GroupTitle = jsonData?.GroupTitle;
            Title = Regex.Replace(Initial_Title, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]", "_");
            GroupTitle = Regex.Replace(Initial_GroupTitle, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]", "_");
        }

        //M4S破解转换
        private void fix_m4s(string targetPath, string outputPath, int bufsize = 256 * 1024 * 1024)
        {
            //确保bufsize大于0,避免错误的缓冲区大小导致崩溃
            if (bufsize <= 0)
                throw new ArgumentException("Buffer size must be greater than 0", nameof(bufsize));

            //以只读模式打开 targetFile（输入文件）
            //以创建/覆盖模式打开 outputFile（输出文件）
            //using 语法确保文件流会被自动关闭，防止资源泄漏
            using (FileStream targetFile = new FileStream(targetPath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                //读取 targetFile 前 32 个字节，假设这是 .m4s 文件的头部信息
                byte[] header = new byte[32];
                int bytesRead = targetFile.Read(header, 0, header.Length);

                //将字节转换为 ASCII 字符串，然后执行字符串替换
                string headerStr = Encoding.ASCII.GetString(header, 0, bytesRead);
                //去掉 "000000000"==》B站加密方式
                headerStr = headerStr.Replace("000000000", "");

                //将修改后的头部信息转换回字节数组并写入 outputFile
                byte[] newHeader = Encoding.ASCII.GetBytes(headerStr);
                outputFile.Write(newHeader, 0, newHeader.Length);

                //复制剩余部分
                //使用大块缓冲区（默认为 256MB）从 targetFile 读取数据，并逐块写入 outputFile，直到文件结束。
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

        //只破解音频
        private void btnAudioCrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolder.Text.Trim()))
            {
                MessageBox.Show("请选择视频文件夹", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Directory.CreateDirectory(outputFolder); // 确保主文件夹存在
            string outputSubFolder = Path.Combine(outputFolder, GroupTitle);
            Directory.CreateDirectory(outputSubFolder); // 创建子文件夹

            //中间文件"_Audio.m4s"
            string outputAudioPath = Path.Combine(outputSubFolder, Title + "_Audio.m4s");
            //最终输出音频文件
            string outputPath = Path.Combine(outputSubFolder, Title + ".m4a");

            //通过文件大小获得音频文件
            if (m4sFiles.Length > 0)
            {
                // 按文件大小排序
                var sortedFiles = m4sFiles.Select(file => new FileInfo(file))
                                          .OrderBy(f => f.Length)
                                          .ToList();

                string smallestFile = sortedFiles.First().FullName; //音频地址=》选文件大小较小的那个

                // 处理最小和最大的 m4s 文件
                fix_m4s(smallestFile, outputAudioPath);
            }
            else
            {
                MessageBox.Show("未找到 .m4s 文件", "错误");
            }

            string arguments = $"-i \"{outputAudioPath}\" -c copy \"{outputPath}\"";
            FFmpegHelper.RunFFmpeg(arguments);
            if (File.Exists(outputAudioPath)) File.Delete(outputAudioPath);

            MessageBox.Show($"文件已保存至: {outputPath}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //清空
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbFolder.Clear();
            tbTitle.Clear();
            tbGroupTitle.Clear();
        }

        // 窗体大小调整时动态调整控件大小和字体
        private void Form2_Resize(object sender, EventArgs e)
        {
            //调整控件大小
            AutoControlSize.ChangeFormControlSize(this);

            // 计算缩放比例，取宽度和高度的最小缩放比例，保证字体不会变形
            float scaleFactor = Math.Min(this.Width / originalFormWidth, this.Height / originalFormHeight);

            // 遍历所有控件，根据缩放比例调整字体大小
            foreach (Control ctrl in this.Controls)
            {
                // 确保字典中有该控件的初始字体大小
                if (originalFontSizes.ContainsKey(ctrl))
                {
                    ctrl.Font = new Font(ctrl.Font.FontFamily, originalFontSizes[ctrl] * scaleFactor);
                }
            }
        }

        // 窗体加载时记录初始值
        private void Form2_Load(object sender, EventArgs e)
        {
            // 记录窗体的初始尺寸
            originalFormWidth = this.Width;
            originalFormHeight = this.Height;

            // 遍历窗体上的所有控件，记录它们的初始字体大小
            foreach (Control ctrl in this.Controls)
            {
                originalFontSizes[ctrl] = ctrl.Font.Size;
            }
        }
    }
}
