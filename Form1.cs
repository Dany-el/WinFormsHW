using System.Drawing.Configuration;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.Keys;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsHomework;

public partial class Form1 : Form
{
    private static int x;
    private static int y;
    
    private Button button1 = new Button();
    private Label labelTime = new Label();
    
    private DateTime NewYear = new DateTime(2022, 12, 31);

    #region Remaining time to NY

    private void RemainingTimeToNewYear()
    {
        labelTime.Size = new Size(900, 500);
        labelTime.Text = DateTime.Now.ToLongTimeString();
        labelTime.Font = new Font("Arial", 30, FontStyle.Regular);

        // создаём таймер
        var t = new Timer();

        // закрепление обработчика
        t.Tick += ShowTime;
        // установка интервала времени
        t.Interval = 1000;
        // стартуем таймер
        t.Start();

        Controls.Add(labelTime);
    }

    private void ShowTime(object? sender, EventArgs e)
    {
        DateTime currentTime = DateTime.Now;
        
        if (currentTime == NewYear)
        {
            labelTime.Text = "Нового года не будет... Дед мороз принял ислам";
        }
        else
        {
            var difference = (NewYear - currentTime);
            string days = difference.Days.ToString();
            string hours = difference.Hours.ToString();
            string minutes = difference.Minutes.ToString();
            string seconds = difference.Seconds.ToString();

            labelTime.Text = $"Days: {days}\nTime: {hours}:{minutes}:{seconds}";
        }
    }

    #endregion
   

    #region Button

    private void MoveButton()
    {
        button1.Text = "Click on me!";
        button1.MouseHover += Button1_MouseHover;

        Controls.Add(button1);
    }

    private void Button1_MouseHover(object? obj, EventArgs e)
    {
        int randomX = new Random().Next(0, Size.Width);
        int randomY = new Random().Next(0, Size.Height);

        button1.Location = new Point(randomX, randomY);
    }

    #endregion
    

    #region Window

    private void MoveWindow()
    {
        KeyPreview = true;
        this.KeyDown += KeyDown_Event;
    }

    private void KeyDown_Event(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Left:
                x -= 50;
                break;
            case Keys.Right:
                x += 50;
                break;
            case Keys.Up:
                y -= 50;
                break;
            case Keys.Down:
                y += 50;
                break;
        }

        Location = new Point(x, y);
    }

    #endregion


    // Creating
    public Form1()
    {
        InitializeComponent();

        // Рандомное расположение кнопки при наводе курсора
        // MoveButton();
        // Перемещение окна при помощи клавиш
        // MoveWindow();

        Text = "До нового года осталось:";
        RemainingTimeToNewYear();
    }
}