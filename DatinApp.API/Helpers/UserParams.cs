using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatinApp.API.Helpers
{
    public class UserParams
    {
		private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

		public int pageSize=5;

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = (value>MaxPageSize)? MaxPageSize:value; }
		}

		public int UserId { get; set; }
		public string Gender { get; set; }



	}
}
