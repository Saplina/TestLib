﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Libraryservice.Models
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Lang { get; set; }

        public int Pages { get; set; }

        public int AgeLimit { get; set; }

        public int PublicationDate { get; set; }

        public IList<Author> Authors { get; set; }

        public override string ToString() => $"{Title} ({Lang}, {PublicationDate}г., {Pages}стр., +{AgeLimit}) / {Category} / {string.Join<Author>(", ", Authors.ToArray())}";


    }
}
