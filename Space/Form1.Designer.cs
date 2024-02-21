namespace Space
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backTimer = new System.Windows.Forms.Timer(components);
            PlayerPaddle = new PictureBox();
            moveTick = new System.Windows.Forms.Timer(components);
            ball = new PictureBox();
            ballTimer = new System.Windows.Forms.Timer(components);
            pointBoard = new Label();
            moveEnemnyTick = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)PlayerPaddle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // backTimer
            // 
            backTimer.Enabled = true;
            backTimer.Tick += backTimer_Tick;
            // 
            // PlayerPaddle
            // 
            PlayerPaddle.BackColor = Color.Red;
            PlayerPaddle.BorderStyle = BorderStyle.FixedSingle;
            PlayerPaddle.Location = new Point(660, 815);
            PlayerPaddle.Name = "PlayerPaddle";
            PlayerPaddle.Size = new Size(190, 30);
            PlayerPaddle.TabIndex = 0;
            PlayerPaddle.TabStop = false;
            // 
            // moveTick
            // 
            moveTick.Enabled = true;
            moveTick.Interval = 20;
            moveTick.Tick += moveTimerEvent;
            // 
            // ball
            // 
            ball.BackColor = SystemColors.ControlLightLight;
            ball.Location = new Point(694, 718);
            ball.Name = "ball";
            ball.Size = new Size(20, 20);
            ball.TabIndex = 1;
            ball.TabStop = false;
            // 
            // ballTimer
            // 
            ballTimer.Enabled = true;
            ballTimer.Interval = 20;
            ballTimer.Tick += ballTick;
            // 
            // pointBoard
            // 
            pointBoard.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            pointBoard.ForeColor = Color.Maroon;
            pointBoard.Location = new Point(12, 9);
            pointBoard.MaximumSize = new Size(1000, 100);
            pointBoard.Name = "pointBoard";
            pointBoard.Size = new Size(157, 48);
            pointBoard.TabIndex = 2;
            pointBoard.Text = "Points:";
            // 
            // moveEnemnyTick
            // 
            moveEnemnyTick.Enabled = true;
            moveEnemnyTick.Tick += moveEnemyTick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1580, 857);
            Controls.Add(pointBoard);
            Controls.Add(ball);
            Controls.Add(PlayerPaddle);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += keyDownMove;
            KeyUp += keyUpStop;
            ((System.ComponentModel.ISupportInitialize)PlayerPaddle).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer backTimer;
        private PictureBox PlayerPaddle;
        private System.Windows.Forms.Timer moveTick;
        private PictureBox ball;
        private System.Windows.Forms.Timer ballTimer;
        private Label pointBoard;
        private System.Windows.Forms.Timer moveEnemnyTick;
    }
}