namespace FirstAplicationWinFormsApp
{
    partial class MainForm
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
            buttonFirst = new Button();
            checkBoxMathematics = new CheckBox();
            checkBoxGerman = new CheckBox();
            labelFavoriteSubject = new Label();
            label1 = new Label();
            labelPizza = new Label();
            radioButtonPizzaYes = new RadioButton();
            radioButtonPizzaNo = new RadioButton();
            labelName = new Label();
            textBoxName = new TextBox();
            labelFavoriteGame = new Label();
            comboBoxFavoriteGame = new ComboBox();
            SuspendLayout();
            // 
            // buttonFirst
            // 
            buttonFirst.BackColor = Color.FromArgb(0, 192, 0);
            buttonFirst.Font = new Font("SimSun", 15.75F, FontStyle.Italic | FontStyle.Strikeout, GraphicsUnit.Point, 0);
            buttonFirst.ForeColor = Color.Red;
            buttonFirst.Location = new Point(222, 12);
            buttonFirst.Name = "buttonFirst";
            buttonFirst.Size = new Size(295, 68);
            buttonFirst.TabIndex = 0;
            buttonFirst.Text = "Pierwszy przycisk2";
            buttonFirst.UseVisualStyleBackColor = false;
            buttonFirst.Click += buttonFirst_Click;
            // 
            // checkBoxMathematics
            // 
            checkBoxMathematics.AutoSize = true;
            checkBoxMathematics.Location = new Point(12, 145);
            checkBoxMathematics.Name = "checkBoxMathematics";
            checkBoxMathematics.Size = new Size(92, 19);
            checkBoxMathematics.TabIndex = 1;
            checkBoxMathematics.Text = "Matematyka";
            checkBoxMathematics.UseVisualStyleBackColor = true;
            // 
            // checkBoxGerman
            // 
            checkBoxGerman.AutoSize = true;
            checkBoxGerman.Location = new Point(12, 170);
            checkBoxGerman.Name = "checkBoxGerman";
            checkBoxGerman.Size = new Size(107, 19);
            checkBoxGerman.TabIndex = 2;
            checkBoxGerman.Text = "Język niemiecki";
            checkBoxGerman.UseVisualStyleBackColor = true;
            // 
            // labelFavoriteSubject
            // 
            labelFavoriteSubject.AutoSize = true;
            labelFavoriteSubject.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelFavoriteSubject.Location = new Point(12, 112);
            labelFavoriteSubject.Name = "labelFavoriteSubject";
            labelFavoriteSubject.Size = new Size(375, 30);
            labelFavoriteSubject.TabIndex = 3;
            labelFavoriteSubject.Text = "Zaznacz ulubione przedmioty w szkole:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(393, 125);
            label1.Name = "label1";
            label1.Size = new Size(273, 64);
            label1.TabIndex = 4;
            label1.Text = "labelFavoriteGame\r\ncomboBoxFavoriteGame";
            // 
            // labelPizza
            // 
            labelPizza.AutoSize = true;
            labelPizza.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelPizza.Location = new Point(20, 208);
            labelPizza.Name = "labelPizza";
            labelPizza.Size = new Size(259, 25);
            labelPizza.TabIndex = 5;
            labelPizza.Text = "Czy lubisz pizze z ananasem?";
            // 
            // radioButtonPizzaYes
            // 
            radioButtonPizzaYes.AutoSize = true;
            radioButtonPizzaYes.Checked = true;
            radioButtonPizzaYes.Location = new Point(20, 236);
            radioButtonPizzaYes.Name = "radioButtonPizzaYes";
            radioButtonPizzaYes.Size = new Size(42, 19);
            radioButtonPizzaYes.TabIndex = 6;
            radioButtonPizzaYes.TabStop = true;
            radioButtonPizzaYes.Text = "Tak";
            radioButtonPizzaYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonPizzaNo
            // 
            radioButtonPizzaNo.AutoSize = true;
            radioButtonPizzaNo.Location = new Point(20, 261);
            radioButtonPizzaNo.Name = "radioButtonPizzaNo";
            radioButtonPizzaNo.Size = new Size(43, 19);
            radioButtonPizzaNo.TabIndex = 7;
            radioButtonPizzaNo.Text = "Nie";
            radioButtonPizzaNo.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelName.Location = new Point(12, 305);
            labelName.Name = "labelName";
            labelName.Size = new Size(172, 30);
            labelName.TabIndex = 8;
            labelName.Text = "Podaj swoje imię:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 338);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(172, 23);
            textBoxName.TabIndex = 9;
            textBoxName.Text = "shsfg";
            // 
            // labelFavoriteGame
            // 
            labelFavoriteGame.AutoSize = true;
            labelFavoriteGame.Location = new Point(362, 206);
            labelFavoriteGame.Name = "labelFavoriteGame";
            labelFavoriteGame.Size = new Size(78, 15);
            labelFavoriteGame.TabIndex = 10;
            labelFavoriteGame.Text = "Ulubiona gra:";
            // 
            // comboBoxFavoriteGame
            // 
            comboBoxFavoriteGame.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFavoriteGame.FormattingEnabled = true;
            comboBoxFavoriteGame.Items.AddRange(new object[] { "Saper", "Memory", "Warcaby" });
            comboBoxFavoriteGame.Location = new Point(362, 235);
            comboBoxFavoriteGame.Name = "comboBoxFavoriteGame";
            comboBoxFavoriteGame.Size = new Size(121, 23);
            comboBoxFavoriteGame.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(676, 433);
            Controls.Add(comboBoxFavoriteGame);
            Controls.Add(labelFavoriteGame);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(radioButtonPizzaNo);
            Controls.Add(radioButtonPizzaYes);
            Controls.Add(labelPizza);
            Controls.Add(label1);
            Controls.Add(labelFavoriteSubject);
            Controls.Add(checkBoxGerman);
            Controls.Add(checkBoxMathematics);
            Controls.Add(buttonFirst);
            Name = "MainForm";
            Text = "Pierwsza aplikacja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonFirst;
        private CheckBox checkBoxMathematics;
        private CheckBox checkBoxGerman;
        private Label labelFavoriteSubject;
        private Label label1;
        private Label labelPizza;
        private RadioButton radioButtonPizzaYes;
        private RadioButton radioButtonPizzaNo;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelFavoriteGame;
        private ComboBox comboBoxFavoriteGame;
    }
}
