
namespace ImageFilters
{
    partial class Adaptiv_Median
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
            this.txt_nValue = new System.Windows.Forms.TextBox();
            this.pictBoxOut = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_showAdaptive = new System.Windows.Forms.Button();
            this.btn_ZGraph = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nValue
            // 
            this.txt_nValue.Location = new System.Drawing.Point(63, 159);
            this.txt_nValue.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nValue.Name = "txt_nValue";
            this.txt_nValue.Size = new System.Drawing.Size(123, 22);
            this.txt_nValue.TabIndex = 0;
            // 
            // pictBoxOut
            // 
            this.pictBoxOut.Location = new System.Drawing.Point(915, 110);
            this.pictBoxOut.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxOut.Name = "pictBoxOut";
            this.pictBoxOut.Size = new System.Drawing.Size(608, 542);
            this.pictBoxOut.TabIndex = 1;
            this.pictBoxOut.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Insert N:";
            // 
            // btn_showAdaptive
            // 
            this.btn_showAdaptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_showAdaptive.Location = new System.Drawing.Point(39, 259);
            this.btn_showAdaptive.Margin = new System.Windows.Forms.Padding(4);
            this.btn_showAdaptive.Name = "btn_showAdaptive";
            this.btn_showAdaptive.Size = new System.Drawing.Size(208, 78);
            this.btn_showAdaptive.TabIndex = 3;
            this.btn_showAdaptive.Text = "Show Image";
            this.btn_showAdaptive.UseVisualStyleBackColor = true;
            this.btn_showAdaptive.Click += new System.EventHandler(this.btn_showAdaptive_Click);
            // 
            // btn_ZGraph
            // 
            this.btn_ZGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ZGraph.Location = new System.Drawing.Point(39, 420);
            this.btn_ZGraph.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ZGraph.Name = "btn_ZGraph";
            this.btn_ZGraph.Size = new System.Drawing.Size(208, 72);
            this.btn_ZGraph.TabIndex = 5;
            this.btn_ZGraph.Text = "ZGraph";
            this.btn_ZGraph.UseVisualStyleBackColor = true;
            this.btn_ZGraph.Click += new System.EventHandler(this.btn_ZGraph_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBack.Location = new System.Drawing.Point(39, 562);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(208, 69);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(291, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 542);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1196, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 36);
            this.label4.TabIndex = 21;
            this.label4.Text = "After";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(531, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 36);
            this.label3.TabIndex = 20;
            this.label3.Text = "Before";
            // 
            // Adaptiv_Median
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1620, 683);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btn_ZGraph);
            this.Controls.Add(this.btn_showAdaptive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictBoxOut);
            this.Controls.Add(this.txt_nValue);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1640, 730);
            this.MinimumSize = new System.Drawing.Size(1636, 730);
            this.Name = "Adaptiv_Median";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaptive Median";
            this.Load += new System.EventHandler(this.Adaptiv_Median_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nValue;
        private System.Windows.Forms.PictureBox pictBoxOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_showAdaptive;
        private System.Windows.Forms.Button btn_ZGraph;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}