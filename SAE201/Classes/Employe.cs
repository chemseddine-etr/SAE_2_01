using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Employe
    {
        private int numemploye;
        private string nomemploye;
        private string prenomemploye;
        private string password;
        private string login;
        private Role unRole;


        public Employe()
        {
        }

        public Employe(int numemploye, string nomemploye, string prenomemploye, string password, string login, Role unRole)
        {
            this.Numemploye = numemploye;
            this.Nomemploye = nomemploye;
            this.Prenomemploye = prenomemploye;
            this.Password = password;
            this.Login = login;
            this.UnRole = unRole;
        }

        public int Numemploye
        {
            get
            {
                return this.numemploye;
            }

            set
            {
                this.numemploye = value;
            }
        }

        public string Nomemploye
        {
            get
            {
                return this.nomemploye;
            }

            set
            {
                this.nomemploye = value;
            }
        }

        public string Prenomemploye
        {
            get
            {
                return this.prenomemploye;
            }

            set
            {
                this.prenomemploye = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
            }
        }

        public Role UnRole
        {
            get
            {
                return this.unRole;
            }

            set
            {
                this.unRole = value;
            }
        }

        public List<Employe> FindAll(Gestion gestion)
        {
            List<Employe> lesEmployes = new List<Employe>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from employe;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesEmployes.Add(new Employe((int)dr["numemploye"], (string)dr["nomemploye"], (string)dr["prenomemploye"], (string)dr["password"], (string)dr["login"],
                        gestion.LesRoles.FirstOrDefault(c => c.Numrole == (int)dr["numrole"])));
            }
            return lesEmployes;
        }
        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into employe (numemploye,numrole,nomemploye,prenomemploye,password,login ) values (@numemploye,@numrole,@nomemploye,@prenomemploye,@password,@login) RETURNING numemploye"))
            {
                cmdInsert.Parameters.AddWithValue("numemploye", this.Numemploye);
                cmdInsert.Parameters.AddWithValue("numrole", this.UnRole.Numrole);
                cmdInsert.Parameters.AddWithValue("nomemploye", this.Nomemploye);
                cmdInsert.Parameters.AddWithValue("prenomemploye", this.Prenomemploye);
                cmdInsert.Parameters.AddWithValue("password", this.Password);
                cmdInsert.Parameters.AddWithValue("login", this.Login);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.Numemploye = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from  employe  where numemploye =@numemploye;"))
            {
                cmdSelect.Parameters.AddWithValue("numemploye",this.Numemploye);

                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.Numemploye = (int)dt.Rows[0]["numemploye"];
                this.UnRole.Numrole = (int)dt.Rows[0]["numrole"];
                this.Nomemploye = (string)dt.Rows[0]["nomemploye"];
                this.Prenomemploye = (string)dt.Rows[0]["prenomemploye"];
                this.Password = (string)dt.Rows[0]["password"];
                this.Login = (string)dt.Rows[0]["login"];

            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update employe set numemploye =@numemploye ,  numrole = @maitre,  nomemploye = @nomemploye , prenomemploye =@prenomemploye , password =@password , login =@login  where numemploye =@numemploye;"))
            {
                cmdUpdate.Parameters.AddWithValue("numemploye", this.Numemploye);
                cmdUpdate.Parameters.AddWithValue("numrole", this.UnRole.Numrole);
                cmdUpdate.Parameters.AddWithValue("nomemploye", this.Nomemploye);
                cmdUpdate.Parameters.AddWithValue("prenomemploye", this.Prenomemploye);
                cmdUpdate.Parameters.AddWithValue("password", this.Password);
                cmdUpdate.Parameters.AddWithValue("login", this.Login);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from employe  where numemploye =@numemploye;"))
            {
                cmdUpdate.Parameters.AddWithValue("numemploye", this.Numemploye);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }


    }
}
