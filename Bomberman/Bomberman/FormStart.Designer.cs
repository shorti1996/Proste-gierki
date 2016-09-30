namespace Bomberman
{
    partial class FormStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxMap = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelMap = new System.Windows.Forms.Label();
            this.panelCommonSettings = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.labelBigTitle = new System.Windows.Forms.Label();
            this.panelTutorial = new System.Windows.Forms.Panel();
            this.richTextBoxTutorial = new System.Windows.Forms.RichTextBox();
            this.panelCommonSettings.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelTutorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxMap
            // 
            this.comboBoxMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMap.FormattingEnabled = true;
            this.comboBoxMap.Location = new System.Drawing.Point(3, 118);
            this.comboBoxMap.Name = "comboBoxMap";
            this.comboBoxMap.Size = new System.Drawing.Size(176, 24);
            this.comboBoxMap.TabIndex = 0;
            this.comboBoxMap.SelectedIndexChanged += new System.EventHandler(this.comboBoxMap_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(3, 365);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(176, 79);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(3, 95);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(102, 17);
            this.labelMap.TabIndex = 2;
            this.labelMap.Text = "Wybierz mapę:";
            // 
            // panelCommonSettings
            // 
            this.panelCommonSettings.Controls.Add(this.panelTutorial);
            this.panelCommonSettings.Controls.Add(this.labelBigTitle);
            this.panelCommonSettings.Controls.Add(this.labelMap);
            this.panelCommonSettings.Controls.Add(this.comboBoxMap);
            this.panelCommonSettings.Location = new System.Drawing.Point(12, 12);
            this.panelCommonSettings.Name = "panelCommonSettings";
            this.panelCommonSettings.Size = new System.Drawing.Size(511, 447);
            this.panelCommonSettings.TabIndex = 3;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonStart);
            this.panelButtons.Location = new System.Drawing.Point(529, 12);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(182, 447);
            this.panelButtons.TabIndex = 4;
            // 
            // labelBigTitle
            // 
            this.labelBigTitle.AutoSize = true;
            this.labelBigTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBigTitle.Location = new System.Drawing.Point(80, 0);
            this.labelBigTitle.Name = "labelBigTitle";
            this.labelBigTitle.Size = new System.Drawing.Size(364, 69);
            this.labelBigTitle.TabIndex = 3;
            this.labelBigTitle.Text = "Bomberman";
            // 
            // panelTutorial
            // 
            this.panelTutorial.Controls.Add(this.richTextBoxTutorial);
            this.panelTutorial.Location = new System.Drawing.Point(0, 148);
            this.panelTutorial.Name = "panelTutorial";
            this.panelTutorial.Size = new System.Drawing.Size(511, 299);
            this.panelTutorial.TabIndex = 4;
            // 
            // richTextBoxTutorial
            // 
            this.richTextBoxTutorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxTutorial.Location = new System.Drawing.Point(5, 3);
            this.richTextBoxTutorial.Name = "richTextBoxTutorial";
            this.richTextBoxTutorial.Size = new System.Drawing.Size(503, 293);
            this.richTextBoxTutorial.TabIndex = 1;
            this.richTextBoxTutorial.Text = "Gracz 1 porusza się WDSA,\npodkłada bombę spacją.\nGracz 2 porusza się strzałkami,\n" +
    "podkłada bombę /.";
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 485);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelCommonSettings);
            this.Name = "FormStart";
            this.Text = "Bomberman- ustawienia";
            this.panelCommonSettings.ResumeLayout(false);
            this.panelCommonSettings.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelTutorial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMap;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.Panel panelCommonSettings;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelTutorial;
        private System.Windows.Forms.RichTextBox richTextBoxTutorial;
        private System.Windows.Forms.Label labelBigTitle;
    }
}