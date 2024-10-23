using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Enums
    {
        internal enum MainMenuChoices
        {
            [Display(Name = "Add Records")]
            AddRecord,

            [Display(Name = "View Records")]
            ViewRecords,

            [Display(Name = "Delete Record")]
            DeleteRecord,

            [Display(Name = "Update Record")]
            UpdateRecord,

            Quit

        }

    }
}
