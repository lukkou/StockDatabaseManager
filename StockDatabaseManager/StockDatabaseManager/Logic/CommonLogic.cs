﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockDatabaseManager.Models;
using StockDatabaseManager.Context;

namespace StockDatabaseManager.Logic
{
	class CommonLogic
	{
		public DatabaseContext Db { get; set; }

		public const string SUCCESS = "Success";

		public const string ERROR = "Error";

		/// <summary>
		/// DatabaseとTableが存在しない場合新規に作成
		/// </summary>
		public void CreateDatacase()
		{
			bool createFlg = Db.Database.CreateIfNotExists();
			if (!createFlg)
			{
				
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void AddSuccessLog(string remarks)
		{
			ExecutionJob jobModel = new ExecutionJob() { GuidKey = Guid.NewGuid(), RegistrationDate = DateTime.Now,RegistrationStatus = SUCCESS , Remarks  = remarks };
			Db.ExecutionJobs.Add(jobModel);
			Db.SaveChanges();
		}
	}
}
