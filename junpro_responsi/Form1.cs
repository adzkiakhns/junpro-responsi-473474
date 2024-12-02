using Npgsql;
using System.Data;
using System.Windows.Forms;
namespace junpro_responsi
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=Creamy123;Database=responsi";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                sql = "SELECT nama_dep FROM public.departemen";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbDept.Items.Add(reader["nama_dep"].ToString());
                }
                reader.Close();

                sql = "SELECT nama_jabatan FROM public.jabatan";
                cmd = new NpgsqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbJabatan.Items.Add(reader["nama_jabatan"].ToString());
                }
                reader.Close();
                if (cbDept.Items.Count > 0) cbDept.SelectedIndex = 0;
                if (cbJabatan.Items.Count > 0) cbJabatan.SelectedIndex = 0;
                sql = "select * from st_select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dgvData.DataSource = dt;
                tbNama.Text = cbDept.Text = cbJabatan.Text = null;
                r = null;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public abstract class BaseEntity
        {
            // OOP Principles 1 (ENCAPSULATION)
            protected NpgsqlConnection conn;
            protected string connstring = "Host=localhost;Port=5432;Username=postgres;Password=Creamy123;Database=responsi";

            public BaseEntity()
            {
                conn = new NpgsqlConnection(connstring);
            }

            // OOP Principles 4 (ABSTRACTION)
            public abstract bool Insert();

            public abstract bool Update();

            public abstract bool Delete();

            public DataTable Select(string sql)
            {
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    da.Fill(dt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Select Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return dt;
            }
        }

        // OOP Principles 2 (INHERITANCE)
        public class Karyawan : BaseEntity
        {
            // OOP Principles 1 (ENCAPSULATION)
            private int IdKaryawan { get; set; }
            private string Nama { get; set; }
            private string NamaDepartemen { get; set; }
            private string NamaJabatan { get; set; }

            public Karyawan(int idKaryawan, string nama, string namaDepartemen, string namaJabatan)
                : base()
            {
                IdKaryawan = idKaryawan;
                Nama = nama;
                NamaDepartemen = namaDepartemen;
                NamaJabatan = namaJabatan;
            }

            // OOP Principles 3 (POLYMORPHISM)
            public override bool Insert()
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM st_insert(:_nama, :_nama_dep, :_nama_jabatan)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("_nama", Nama);
                        cmd.Parameters.AddWithValue("_nama_dep", NamaDepartemen);
                        cmd.Parameters.AddWithValue("_nama_jabatan", NamaJabatan);

                        int result = (int)cmd.ExecuteScalar();
                        conn.Close();

                        return result == 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Insert Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // OOP Principles 3 (POLYMORPHISM)
            public override bool Update()
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM st_update(:_id_karyawan, :_nama, :_nama_dep, :_nama_jabatan)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("_id_karyawan", IdKaryawan);
                        cmd.Parameters.AddWithValue("_nama", Nama);
                        cmd.Parameters.AddWithValue("_nama_dep", NamaDepartemen);
                        cmd.Parameters.AddWithValue("_nama_jabatan", NamaJabatan);

                        int result = (int)cmd.ExecuteScalar();
                        conn.Close();

                        return result == 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // OOP Principles 3 (POLYMORPHISM)
            public override bool Delete()
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM st_delete(:_id_karyawan)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("_id_karyawan", IdKaryawan);

                        int result = (int)cmd.ExecuteScalar();
                        conn.Close();

                        return result == 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Delete Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan(0, tbNama.Text, cbDept.Text, cbJabatan.Text);
            if (karyawan.Insert())
            {
                MessageBox.Show("Karyawan berhasil diinsert", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Insert failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataGridView()
        {
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = "SELECT * FROM st_select()";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            NpgsqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            dgvData.DataSource = dt;
            conn.Close();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan(int.Parse(r.Cells["_id_karyawan"].Value.ToString()), tbNama.Text, cbDept.Text, cbJabatan.Text);
            if (karyawan.Update())
            {
                MessageBox.Show("Karyawan berhasil diupdate", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Update failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan(int.Parse(r.Cells["_id_karyawan"].Value.ToString()), "", "", "");
            if (karyawan.Delete())
            {
                MessageBox.Show("Karyawan berhasil dihapus", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Delete failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvData.Rows[e.RowIndex];
                tbNama.Text = r.Cells["_nama"].Value.ToString();
                cbDept.Text = r.Cells["_nama_dep"].Value.ToString();
                cbJabatan.Text = r.Cells["_nama_jabatan"].Value.ToString();
            }
        }
    }
}
