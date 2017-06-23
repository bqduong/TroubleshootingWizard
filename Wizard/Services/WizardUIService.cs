using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizard.Enums;

namespace Wizard.Services
{
    public class WizardUIService
    {
        private Random random;
        public WizardUIService()
        {
            this.random = new Random();
        }

        public bool RunDiagHelperMethod(DIAG_HELPER_METHODS myHelperMethod)
        {
            switch (myHelperMethod)
            {
                case DIAG_HELPER_METHODS.RUN_SOLVENT_LEAK_TEST:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.RUN_SYRINGE_EXCHANGE_UTILITY:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.RESET_AUTOSAMPLER_SYRINGE_COUNT:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.MOVE_ARM_AWAY_FROM_WASH_STATION:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.RESET_WASH_PORT_SEPTUM_COUNT:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.MOVE_ARM_HOME:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.RUN_WASH_PORT_SEPTUM_LEAK_TEST:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.CONFIRM_WASH_PORT_SEPTUM_POSITION:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.RESET_INJECTION_PORT_SEPTUM_CONT:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.CONFIRM_INJECTION_PORT_SEPTUM_POSITION:
                    return random.NextDouble() > 0.5;
                case DIAG_HELPER_METHODS.RUN_SYRINGE_CELL_PATH_LEAK_TEST:
                    return random.NextDouble() > 0.5;
                    return true;
                case DIAG_HELPER_METHODS.RESET_TEST_SYRINGE_COUNT:
                    return random.NextDouble() > 0.5;
                default:
                    return random.NextDouble() > 0.5;
            }

        }
    }
}
