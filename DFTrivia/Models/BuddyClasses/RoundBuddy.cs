using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DFTrivia.Models
{
    [MetadataType(typeof(RoundBuddy))]
    public partial class Round
    {

    }

    sealed class RoundBuddy
    {
        public int RoundID { get; set; }
        public int Rounds { get; set; }

        [Display(Name ="Question")]
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        [Display(Name ="Game Type")]
        public string GameType { get; set; }
    }
}