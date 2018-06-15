using System.Drawing;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class ProgramInfoWindow : Form
    {
        internal Channel Channel { get; set; }
        private ProgramList progList;
        private ProgramListItem progListItem;
        private ProgramListItem currentProgram;

        public ProgramInfoWindow()
        {
            InitializeComponent();
        }

        private void ProgramInfoWindow_Load(object sender, System.EventArgs e)
        {
            Channel channelInfo = (Application.OpenForms["RemoteControl"] as RemoteControl).channelProgramInfo.Payload.Channel;
            progList = new ProgramList();
            progListItem = new ProgramListItem();
            currentProgram = new ProgramListItem();

            foreach (ProgramListItem item in (Application.OpenForms["RemoteControl"] as RemoteControl).channelProgramInfo.Payload.ProgramList)
            {
                progList.Load(item);
            }

            foreach (ProgramListItem item in progList.programList)
            {
                if (item.Percent != 0)
                {
                    currentProgram = item;
                    lbCurrentChannelName.Text = Channel.ChannelName;
                    lbCurrentChannelProgramName.Text = item.ProgramName;
                    lbGenre.Text = item.Genre;
                    pbElapsedPercentage.Value = item.Percent;
                }
            }

            dgvProgramList.DataSource = progList.programList;

            dgvProgramList.Columns["StartTime"].HeaderText = "Start time";
            dgvProgramList.Columns["StartTime"].Width = 30;
            dgvProgramList.Columns["StartTime"].DisplayIndex = 1;
            dgvProgramList.Columns["ProgramName"].HeaderText = "Program name";
            dgvProgramList.Columns["ProgramName"].DisplayIndex = 2;
            dgvProgramList.Columns["ProgramName"].DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
            dgvProgramList.Columns["DurationMin"].HeaderText = "Duration";
            dgvProgramList.Columns["DurationMin"].Width = 30;
            dgvProgramList.Columns["DurationMin"].DisplayIndex = 3;
            dgvProgramList.Columns["Genre"].DisplayIndex = 4;

            dgvProgramList.Columns["ChannelId"].Visible = false;
            dgvProgramList.Columns["StartDateTime"].Visible = false;
            dgvProgramList.Columns["ProgramId"].Visible = false;
            dgvProgramList.Columns["SignalChannelId"].Visible = false;
            dgvProgramList.Columns["TableId"].Visible = false;
            dgvProgramList.Columns["EndDateTime"].Visible = false;
            dgvProgramList.Columns["Percent"].Visible = false;
            dgvProgramList.Columns["LocalStartDateTime"].Visible = false;
            dgvProgramList.Columns["LocalEndDateTime"].Visible = false;
            dgvProgramList.Columns["Duration"].Visible = false;
            dgvProgramList.Columns["EndTime"].Visible = false;

            dgvProgramList.AutoResizeColumns();
            dgvProgramList.RowHeadersVisible = false;
            dgvProgramList.AutoGenerateColumns = false;
            dgvProgramList.MultiSelect = false;
            dgvProgramList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in dgvProgramList.Rows)
            {
                if (row.Cells["ProgramId"].Value.ToString() == currentProgram.ProgramId)
                    row.Selected = true;
                dgvProgramList.FirstDisplayedScrollingRowIndex = dgvProgramList.SelectedRows[0].Index;
            }
        }
    }
}
