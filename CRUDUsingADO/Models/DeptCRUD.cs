using System.Data.SqlClient;

namespace CRUDUsingADO.Models
{
    public class DeptCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public DeptCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Dept> DeptList()
        {
            List<Dept> deptlist = new List<Dept>();
            string qry = "select * from tblDept";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    Dept dept = new Dept();
                    dept.DeptId = Convert.ToInt32(dr["deptid"]);
                    dept.DeptName = dr["deptname"].ToString();
                    deptlist.Add(dept);
                }
            }
            con.Close();
            return deptlist;
        }
        public Dept GetDeptById(int id)
        {
            Dept dept = new Dept();
            string qry = "select * from tblDept where deptid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.DeptId = Convert.ToInt32(dr["deptid"]);
                    dept.DeptName = dr["deptname"].ToString();
                }
            }
            con.Close();
            return dept;
        }
        public int AddDept(Dept dept)
        {
            int result = 0;
            string qry = "insert into tblDept values(@deptname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptname", dept.DeptName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateDept(Dept dept)
        {
            int result = 0;
            string qry = "update tblDept set deptname=@deptname where deptid=@deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptname", dept.DeptName);
            cmd.Parameters.AddWithValue("@deptid", dept.DeptId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteDept(int id)
        {
            int result = 0;
            string qry = "delete from  tblDept where deptid=@deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptid",id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
