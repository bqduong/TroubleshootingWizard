using System.Xml;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace TroubleshootingWizard
{
    partial class InitiumTroubleshoot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitiumTroubleshoot));
            this.glassExtenderProvider1 = new Vanara.Interop.DesktopWindowManager.GlassExtenderProvider();
            this.wizardPage = new AeroWizard.WizardPage();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.description = new System.Windows.Forms.Label();
            this.troubleshootImage = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.wizardControl = new AeroWizard.WizardControl();
            this.wizardPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.troubleshootImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardPage
            // 
            this.wizardPage.Controls.Add(this.axWindowsMediaPlayer);
            this.wizardPage.Controls.Add(this.radioButton2);
            this.wizardPage.Controls.Add(this.radioButton1);
            this.wizardPage.Controls.Add(this.progressBar);
            this.wizardPage.Controls.Add(this.troubleshootImage);
            this.wizardPage.Controls.Add(this.description);
            this.wizardPage.HelpText = "";
            this.wizardPage.Name = "wizardPage";
            this.wizardPage.Size = new System.Drawing.Size(689, 541);
            this.wizardPage.TabIndex = 0;
            this.wizardPage.Text = "Page Title";
            this.wizardPage.HelpClicked += new System.EventHandler(this.wizardControl_loadManualClicked);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(6, 44);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(640, 480);
            this.axWindowsMediaPlayer.TabIndex = 3;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(3, 0);
            this.description.MaximumSize = new System.Drawing.Size(550, 60);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(32, 15);
            this.description.TabIndex = 0;
            this.description.Text = "label";
            // 
            // troubleshootImage
            // 
            this.troubleshootImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.troubleshootImage.Location = new System.Drawing.Point(6, 44);
            this.troubleshootImage.Name = "troubleshootImage";
            this.troubleshootImage.Size = new System.Drawing.Size(640, 480);
            this.troubleshootImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.troubleshootImage.TabIndex = 1;
            this.troubleshootImage.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(207, 482);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(250, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 2;
            this.progressBar.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 19);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.Click += new System.EventHandler(this.wizardControl_enableNext);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 69);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(94, 19);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.Click += new System.EventHandler(this.wizardControl_enableNext);
            // 
            // wizardControl
            // 
            this.wizardControl.BackColor = System.Drawing.Color.White;
            this.wizardControl.CancelButtonText = "&No";
            this.wizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl.FinishButtonText = "Next";
            this.wizardControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl.Location = new System.Drawing.Point(0, 0);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.Pages.Add(this.wizardPage);
            this.wizardControl.Size = new System.Drawing.Size(736, 695);
            this.wizardControl.TabIndex = 0;
            this.wizardControl.Title = "Initium Troubleshooting Wizard";
            this.wizardControl.TitleIcon = ((System.Drawing.Icon)(resources.GetObject("wizardControl.TitleIcon")));
            this.wizardControl.SelectedPageChanged += new System.EventHandler(this.wizardControl_SelectedPageChanged);
            this.wizardControl.SelectedPageChangedUsingNo += new System.EventHandler(this.wizardControl_SelectedPageChanged2);
            // 
            // InitiumTroubleshoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 695);
            this.Controls.Add(this.wizardControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.glassExtenderProvider1.SetGlassMargins(this, new System.Windows.Forms.Padding(0));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitiumTroubleshoot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InitiumTroubleshoot_Load);
            this.wizardPage.ResumeLayout(false);
            this.wizardPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.troubleshootImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).EndInit();
            this.ResumeLayout(false);

            this.wizardControl.Finished += WizardControlOnFinished;
        }

        private bool IsDiagPassed { get; set; }

        private void WizardControlOnFinished(object sender, EventArgs eventArgs)
        {
            this.IsDiagPassed = true;
            this.DialogResult = DialogResult.OK;
        }

        #endregion
        private Vanara.Interop.DesktopWindowManager.GlassExtenderProvider glassExtenderProvider1;
        private AeroWizard.WizardPage wizardPage;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox troubleshootImage;
        private System.Windows.Forms.Label description;
        private AeroWizard.WizardControl wizardControl;
    }
}