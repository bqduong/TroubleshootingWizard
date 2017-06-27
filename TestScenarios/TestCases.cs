using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TroubleshootingWizard;

namespace TestScenarios
{
    public partial class TestCases : Form
    {
        public TestCases()
        {
            InitializeComponent();
        }

        private void TestCases_Load(object sender, EventArgs e)
        {

        }
        
        private void solventLevels_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\SolventLevels.xml");
            wizard.ShowDialog();
        }

        private void washPortSeptum_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\WashPortSeptum.xml");
            wizard.ShowDialog();
        }

        private void injectionPortSeptum_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\InjectionPortSeptum.xml");
            wizard.ShowDialog();
        }

        private void autoSampleSyringe_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\AutoSamplerSyringe.xml");
            wizard.ShowDialog();
        }

        private void testSyringe_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\TestSyringe.xml");
            wizard.ShowDialog();
        }

        private void uti_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\ReplaceChip.xml");
            wizard.ShowDialog();
        }

        private void syringeCell_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\SyringeCell.xml");
            wizard.ShowDialog();
        }

        private void syringeChip_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\SyringeChip.xml");
            wizard.ShowDialog();
        }

        private void reservoirChip_Click(object sender, EventArgs e)
        {
            InitiumTroubleshoot wizard = new InitiumTroubleshoot("C:\\TroubleshootingWizard\\ReservoirChip.xml");
            wizard.ShowDialog();
        }
    }
}