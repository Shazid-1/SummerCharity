using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public partial class DonatorService
	{
		public static List<EventDonatorDTO> History(string token)
		{
			string username = DataAccess.TokenData().Get(token).Username;
			var member = DataAccess.DonatorData().Get(username);
			var events = DataAccess.EventDonatorData().Get().Where(x => x.DId == member.Id);
			var mapper = MapperService<EventDonator, EventDonatorDTO>.GetMapper();
			var con = mapper.Map<List<EventDonatorDTO>>(events);
			return con;
		}
	}
}
