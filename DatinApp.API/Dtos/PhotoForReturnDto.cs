﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatinApp.API.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}
