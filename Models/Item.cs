using System;
using System.ComponentModel.DataAnnotations;

namespace dropbox.Models
{
    public class Item
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm")]
        public DateTime Uploaded { get; set; }
        public string DisplayName { get; set; }
        public byte[] Contents { get; set; }
    }
}