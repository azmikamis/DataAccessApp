using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using DataAccessApp.Models;
using DataAccessApp.Helpers;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DataAccessApp.ViewModels
{
    public class DataSelectionViewModel : DependencyObject
    {
        private readonly Dispatcher currentDispatcher;
        private Database database;
        public ObservableCollection<Data> DataItems { get; set; }

        public DataSelectionViewModel()
        {
            this.currentDispatcher = Dispatcher.CurrentDispatcher;
            this.database = DatabaseFactory.CreateDatabase();
            this.DataItems = new ObservableCollection<Data>();

            EventSystem.Subscribe<Boolean>(Load);
            EventSystem.Subscribe<String>(Delete);
        }

        public void Load(Boolean msg)
        {
            DataItems.Clear();
            using (IDataReader reader = this.database.ExecuteReader(this.database.GetSqlStringCommand("SELECT * FROM PRODUCTS")))
            {
                while (reader.Read())
                {
                    DataItems.Add(new Data { Col1 = reader["ProductID"].ToString(), Col2 = reader["ModelNumber"].ToString() });
                }
            }
        }

        public void Delete(String productID)
        {
            string query = string.Format("DELETE FROM PRODUCTS WHERE ProductID={0}", productID);
            this.database.ExecuteNonQuery(this.database.GetSqlStringCommand(query));
            Load(true);
        }
    }
}
