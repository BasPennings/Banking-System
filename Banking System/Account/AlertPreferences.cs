using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Account
{
    // Preferences for receiving account alerts (e.g., low balance alerts, transaction notifications).
    public enum AlertPreferences
    {
        LowBalanceAlerts,       // Preferences for receiving notifications when the account balance falls below a certain threshold.
        TransactionAlerts,      // Preferences for receiving notifications for specific transactions, such as large withdrawals or deposits.
        SecurityAlerts,         // Preferences for receiving notifications about potential security breaches or suspicious activities.
        StatementAvailability,  // Preferences for receiving notifications when new account statements are available for viewing or download.
        CustomAlerts            // Preferences for setting up custom alerts based on specific account criteria or user-defined parameters.
    }

}
