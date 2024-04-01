using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Account
{
    // Preferences for receiving account statements (e.g., paper statements or electronic statements).
    public enum StatementDeliveryMethods
    {
        PaperStatement,       // Indicates delivery of account statements via postal mail on paper.
        ElectronicStatement,  // Indicates delivery of account statements electronically, typically in PDF format via email or online banking portals.
        OnlineBanking,        // Indicates real-time access to account information through secure online banking platforms or mobile banking apps.
        CombinedDelivery      // Indicates a combination of paper and electronic delivery methods, allowing account holders to receive statements both physically and electronically based on their preferences.
    }

}
