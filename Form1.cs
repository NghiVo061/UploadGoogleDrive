using System.Threading;
using UploadGoogleDrive;

namespace GoogleDrive
{
    public partial class Form1 : Form
    {
        GoogleDriveApi _api = new GoogleDriveApi("271012486908-f7m35hripfigbgi0rkr76a1n9s4psuok.apps.googleusercontent.com", "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", "giaiphapmmo_google_api");
        private CancellationTokenSource _cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnKetNoiTaiKhoanGoogle_Click_1(object sender, EventArgs e)
        {
            await _api.LoginAsync();

            if (GoogleDriveApi.CheckLogin(_api.LocalUserName))
                txtNhatKy.AppendText("Đã đăng nhập\r\n");
        }

        private void btnChonTep_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                txtDuongDanTep.Text = open.FileName;
        }

        private async void btnTaiLen_Click_1(object sender, EventArgs e)
        {
            await _api.LoginAsync();
            if (GoogleDriveApi.CheckLogin(_api.LocalUserName))
            {
                if (string.IsNullOrWhiteSpace(txtDuongDanTep.Text))
                {
                    MessageBox.Show("Vui lòng chọn tệp trước khi tải lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _cancellationTokenSource = new CancellationTokenSource();
                string folderId = await _api.CreateFolderIfNotExistAync("Test Code Tai Tep Len GG Drive");
                try
                {
                    string fileId = await _api.UploadFileAsync(txtDuongDanTep.Text, _cancellationTokenSource.Token, folderId);
                    string linkFile = _api.GetLinkFile(fileId);
                    txtNhatKy.AppendText($"Tải lên thành công, đường dẫn tệp:\r\n{linkFile}\r\n");
                }
                catch (OperationCanceledException)
                {
                    txtNhatKy.AppendText("Tải lên đã bị hủy bỏ\r\n");
                }
                catch (Exception ex)
                {
                    txtNhatKy.AppendText($"Lỗi xảy ra: {ex.Message}\r\n");
                }
            }
        }

        private void SignOut_btn_Click(object sender, EventArgs e)
        {
            GoogleDriveApi.Signout(_api.LocalUserName);
            txtNhatKy.AppendText("Đã ngắt kết nối\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}