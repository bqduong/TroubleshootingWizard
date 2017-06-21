namespace TestScenarios
{
    partial class TestCases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestCases));
            this.SolventLevels = new System.Windows.Forms.Button();
            this.WashPortSeptum = new System.Windows.Forms.Button();
            this.InjectionPortSeptum = new System.Windows.Forms.Button();
            this.AutoSamplerSyringe = new System.Windows.Forms.Button();
            this.TestSyringe = new System.Windows.Forms.Button();
            this.ReplaceChip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SolventLevels
            // 
            this.SolventLevels.Location = new System.Drawing.Point(12, 12);
            this.SolventLevels.Name = "SolventLevels";
            this.SolventLevels.Size = new System.Drawing.Size(155, 41);
            this.SolventLevels.TabIndex = 0;
            this.SolventLevels.Text = "Solvent Levels";
            this.SolventLevels.UseVisualStyleBackColor = true;
            this.SolventLevels.Click += new System.EventHandler(this.solventLevels_Click);
            // 
            // WashPortSeptum
            // 
            this.WashPortSeptum.Location = new System.Drawing.Point(191, 12);
            this.WashPortSeptum.Name = "WashPortSeptum";
            this.WashPortSeptum.Size = new System.Drawing.Size(155, 41);
            this.WashPortSeptum.TabIndex = 1;
            this.WashPortSeptum.Text = "Wash Port Septum";
            this.WashPortSeptum.UseVisualStyleBackColor = true;
            this.WashPortSeptum.Click += new System.EventHandler(this.washPortSeptum_Click);
            // 
            // InjectionPortSeptum
            // 
            this.InjectionPortSeptum.Location = new System.Drawing.Point(368, 12);
            this.InjectionPortSeptum.Name = "InjectionPortSeptum";
            this.InjectionPortSeptum.Size = new System.Drawing.Size(155, 41);
            this.InjectionPortSeptum.TabIndex = 2;
            this.InjectionPortSeptum.Text = "Injection Port Septum";
            this.InjectionPortSeptum.UseVisualStyleBackColor = true;
            this.InjectionPortSeptum.Click += new System.EventHandler(this.injectionPortSeptum_Click);
            // 
            // AutoSamplerSyringe
            // 
            this.AutoSamplerSyringe.Location = new System.Drawing.Point(12, 69);
            this.AutoSamplerSyringe.Name = "AutoSamplerSyringe";
            this.AutoSamplerSyringe.Size = new System.Drawing.Size(155, 41);
            this.AutoSamplerSyringe.TabIndex = 3;
            this.AutoSamplerSyringe.Text = "AutoSampler Syringe";
            this.AutoSamplerSyringe.UseVisualStyleBackColor = true;
            this.AutoSamplerSyringe.Click += new System.EventHandler(this.autoSampleSyringe_Click);
            // 
            // TestSyringe
            // 
            this.TestSyringe.Location = new System.Drawing.Point(191, 69);
            this.TestSyringe.Name = "TestSyringe";
            this.TestSyringe.Size = new System.Drawing.Size(155, 41);
            this.TestSyringe.TabIndex = 4;
            this.TestSyringe.Text = "Test Syringe";
            this.TestSyringe.UseVisualStyleBackColor = true;
            this.TestSyringe.Click += new System.EventHandler(this.testSyringe_Click);
            // 
            // UTI
            // 
            this.ReplaceChip.Location = new System.Drawing.Point(368, 69);
            this.ReplaceChip.Name = "ReplaceChip";
            this.ReplaceChip.Size = new System.Drawing.Size(155, 41);
            this.ReplaceChip.TabIndex = 5;
            this.ReplaceChip.Text = "Replace Chip";
            this.ReplaceChip.UseVisualStyleBackColor = true;
            this.ReplaceChip.Click += new System.EventHandler(this.uti_Click);
            // 
            // TestCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 122);
            this.Controls.Add(this.ReplaceChip);
            this.Controls.Add(this.TestSyringe);
            this.Controls.Add(this.AutoSamplerSyringe);
            this.Controls.Add(this.InjectionPortSeptum);
            this.Controls.Add(this.WashPortSeptum);
            this.Controls.Add(this.SolventLevels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestCases";
            this.Text = "Wizard Test Cases";
            this.Load += new System.EventHandler(this.TestCases_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SolventLevels;
        private System.Windows.Forms.Button WashPortSeptum;
        private System.Windows.Forms.Button InjectionPortSeptum;
        private System.Windows.Forms.Button AutoSamplerSyringe;
        private System.Windows.Forms.Button TestSyringe;
        private System.Windows.Forms.Button ReplaceChip;
    }
}

