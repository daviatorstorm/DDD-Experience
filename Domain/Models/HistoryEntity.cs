using System;

namespace Domain.Models
{
    public class HistoryEntity : Entity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModifies { get; set; }
    }
}