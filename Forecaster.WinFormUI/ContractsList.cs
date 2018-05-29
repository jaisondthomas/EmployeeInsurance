using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataFile;
using Forecaster.Repository;
using Forecaster.VolumeForecaster;


namespace Forecaster.WinFormUI
{
    public partial class frmContracts : Form
    {
        private long _contractId;
        public frmContracts()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var contractFilePath = Path.GetFullPath(@"..\..\DataFiles\Contracts.xml");
            ListContracts( contractFilePath );
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtContractId.Text = string.Empty;
            txtClientId.Text = string.Empty;
            dtpStartDate.Text = string.Empty;
            dtpEndDate.Text = string.Empty;
        }
        private void ListContracts( string contractFilePath )
        {
            var reader = new ContractReader(contractFilePath);
            var dataFile = new ContractData( reader);
            var repository = new ContractRepository(dataFile);
            gridViewContracts.DataSource = repository.Contracts();
          
        }

        private void btnTotalContractedVolume_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContractId.Text == string.Empty)
                {
                    MessageBox.Show(
                        @"No contract is selected to show the total site volume , please select a contract from the list",
                        @"No contract selected");
                    return;
                }

                var totalContractedVolume = TotalContractedVolume(_contractId);
                MessageBox.Show(
                    totalContractedVolume.ToString(CultureInfo.InvariantCulture),
                    @"Total contracted volume");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private static decimal TotalContractedVolume(long contractId)
        {
            var contractFile = Path.GetFullPath(@"..\..\DataFiles\Contracts.xml");
            var contractProductFile = Path.GetFullPath(@"..\..\DataFiles\ContractProducts.xml");
            var contractProductSiteFile =
                Path.GetFullPath(@"..\..\DataFiles\ContractProductSites.xml");
            var siteVolumeFile = Path.GetFullPath(@"..\..\DataFiles\SiteVolumes.xml");

            var calculculator = new SiteVolumeCalculator();
            var forecaster = new SiteVolumeForecaster(calculculator);

            var contractReader = new ContractReader(contractFile);
            var contractData = new ContractData(contractReader);
            var contractRepo = new ContractRepository(contractData);


            var contractProductReader = new ContractProductReader(contractProductFile);
            var contractProductData = new ContractProductData(contractProductReader);
            var productsRepo = new ContractProductRepository(contractProductData);


            var contractProductSiteReader =
                new ContractProductSiteReader(contractProductSiteFile);
            var contractProductSiteData = new ContractProductSiteData(contractProductSiteReader);
            var sitesRepo =
                new ContractProductSiteRepository(contractProductSiteData);


            var contractProductSiteVolumeReader =
                new ContractProductSiteVolumeReader(siteVolumeFile);
            var contractProductSiteVolumeData =
                new ContractProductSiteVolumeData(contractProductSiteVolumeReader);
            var volumesRepo =
                new ContractProductSiteVolumeRepository(contractProductSiteVolumeData);


            var contract = contractRepo.Contract(x => x.Id == contractId);
            var contracts = contractRepo.Contracts().ToList();

            var contractProducts = productsRepo.Records().ToList();
            var contractProductSites = sitesRepo.Records().ToList();
            var siteVolumes = volumesRepo.Records().ToList();

            var total = forecaster.TotalContractedVolume(contract, contracts,
                contractProducts, contractProductSites, siteVolumes);

            return total;
        }

        private void gridViewContracts_RowHeaderMouseClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            _contractId = Convert.ToInt64(gridViewContracts.Rows[e.RowIndex].Cells[2]
                .Value.ToString());
            txtContractId.Text = gridViewContracts.Rows[e.RowIndex].Cells[2].Value
                .ToString();
            txtClientId.Text = gridViewContracts.Rows[e.RowIndex].Cells[3].Value
                .ToString();
            dtpStartDate.Text = gridViewContracts.Rows[e.RowIndex].Cells[0].Value
                .ToString();
            dtpEndDate.Text = gridViewContracts.Rows[e.RowIndex].Cells[1].Value
                .ToString();
        }
    }
}
