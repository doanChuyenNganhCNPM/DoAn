using MetroSet_UI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomMessageBox : Form
{
    public DialogResult Result { get; private set; } = DialogResult.None;

    public CustomMessageBox(string message, string title, int width = 400, int height = 200, string titleColor = "#ADD8E6", string textColor = "#000000", bool isYesNo = false)
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.Width = width;
        this.Height = height;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;

        Label lblTitle = new Label
        {
            Text = title.ToUpper(),
            AutoSize = false,
            Width = this.Width,
            Height = 50,
            Top = 0,
            Left = 0,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(titleColor),
            BackColor = Color.WhiteSmoke
        };

        Font messageFont = new Font("Segoe UI", 14, FontStyle.Regular);
        int maxWidth = this.Width - 80;
        SizeF textSize;
        using (Graphics g = this.CreateGraphics())
        {
            textSize = g.MeasureString(message, messageFont, maxWidth);
        }

        int calculatedHeight = (int)Math.Ceiling(textSize.Height);
        int lblMessageWidth = (int)Math.Ceiling(textSize.Width);

        Label lblMessage = new Label
        {
            Text = message,
            AutoSize = false,
            Width = Math.Min(lblMessageWidth, maxWidth),
            Height = Math.Min(calculatedHeight, this.Height - 20 - 50 - 60),
            Left = 20,
            Top = 60,
            Font = messageFont,
            ForeColor = ColorTranslator.FromHtml(textColor),
            BackColor = this.BackColor,
            TextAlign = ContentAlignment.TopLeft
        };

        if (isYesNo)
        {
            MetroSetButton btnYes = new MetroSetButton
            {
                Text = "Xác nhận",
                Width = 100,
                Height = 40,
                BackColor = Color.LightGreen,
                ForeColor = Color.Black,
                StyleManager = null
            };
            btnYes.Click += (sender, e) =>
            {
                this.Result = DialogResult.Yes;
                this.Close();
            };

            MetroSetButton btnNo = new MetroSetButton
            {
                Text = "Hủy bỏ",
                Width = 100,
                Height = 40,
                BackColor = Color.LightCoral,
                ForeColor = Color.Black,
                StyleManager = null
            };
            btnNo.Click += (sender, e) =>
            {
                this.Result = DialogResult.No;
                this.Close();
            };

            btnYes.Left = this.Width - 220;
            btnYes.Top = this.Height - 60;

            btnNo.Left = this.Width - 110;
            btnNo.Top = this.Height - 60;

            this.Controls.Add(btnYes);
            this.Controls.Add(btnNo);
        }
        else
        {
            MetroSetButton btnOk = new MetroSetButton
            {
                Text = "OK",
                Width = 100,
                Height = 40,
                BackColor = Color.LightGreen,
                ForeColor = Color.Black,
                StyleManager = null
            };
            btnOk.Click += (sender, e) =>
            {
                this.Result = DialogResult.OK;
                this.Close();
            };

            btnOk.Left = this.Width - 120;
            btnOk.Top = this.Height - 60;

            this.Controls.Add(btnOk);
        }

        this.Controls.Add(lblTitle);
        this.Controls.Add(lblMessage);
    }

    public static void Show(string message, string title = "Thông báo", int width = 400, int height = 200, string titleColor = "#ADD8E6", string textColor = "#000000")
    {
        CustomMessageBox box = new CustomMessageBox(message, title, width, height, titleColor, textColor);
        box.ShowDialog();
    }

    public static DialogResult ShowYesNo(string message, string title = "Xác nhận", int width = 400, int height = 200, string titleColor = "#FF0000", string textColor = "#000000")
    {
        CustomMessageBox box = new CustomMessageBox(message, title, width, height, titleColor, textColor, true);
        box.ShowDialog();
        return box.Result;
    }
}
