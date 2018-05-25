using System;

namespace Domain.Models
{
    public class Retailer : HistoryEntity
    {
        public string Name { get; set; }
        public Group Group { get; set; }
    }
}