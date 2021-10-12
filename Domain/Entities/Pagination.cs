using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Entities
{
    [DataContract]
   public sealed class Pagination <Y> where Y :class
    {

        [DataMember(Name = "page")]
        public int Page { get; private set; }

        [DataMember(Name = "total_entries")]
        public int TotalEntries { get; private set; }

        [DataMember(Name = "entries_per_page")]
        public int EntriesPerPage { get; private set; }

        [DataMember(Name = "entries")]
        public IList<Y> Entries { get; private set; }

        public Pagination(int page, int totalEntries, int entriesPerPage, IList<Y> entries)
        {
            Page = page;
            TotalEntries = totalEntries;
            EntriesPerPage = entriesPerPage;
            Entries = entries;
        }

        //public Pagination(IList<Y> entries)
        //{
        //    Entries = entries;
        //}

    }
}
