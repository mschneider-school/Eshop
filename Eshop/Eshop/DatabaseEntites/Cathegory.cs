﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Cathegory
    {
        public const string TableName = "Cathegory";
        public const string IDColumn = "CathegoryID";
        public const string DescriptionColumn = "Description";
        
        public long ID { get; private set; }
        public string Description { get; private set; }

        public Cathegory(long id, string description)
        {
            ID = id;
            Description = description;
        }
    }
}