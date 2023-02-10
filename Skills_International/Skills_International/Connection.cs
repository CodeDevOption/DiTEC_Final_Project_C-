using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name: Lahiru Sadaruwan
 * RegNo :E161509
 * Github Profile link: 
 * Student Form Created Date:2023/02/04
 * Last Edited Date: Date:2023/02/04
 * All Right Recerved
 */

namespace Skills_International
{
    class Connection
    {
        string connection_String = @"Data Source=DESKTOP-V9SH1LB;Initial Catalog=Skills_International;Integrated Security=True";
        public SqlConnection GetConnection() {
            return new SqlConnection(connection_String);
        }
    }
}
