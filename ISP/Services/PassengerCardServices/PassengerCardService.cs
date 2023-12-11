using ISP.Models;
using Microsoft.JSInterop;
using Microsoft.VisualBasic;
using OfficeOpenXml;
using System.Security.Cryptography.X509Certificates;

namespace ISP.Services.PassengerCardServices
{
    public class PassengerCardService : IPassengerCardService
    {
        private readonly HttpClient client;

        private readonly IJSRuntime JS;

        public PassengerCardService(IJSRuntime jS, HttpClient client)
        {
            JS = jS;
            this.client = client;
        }


        public async Task<bool> CreatePassengerCardAsync(PassengerCard passengerCard)
        {
            try
            {

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new(await client.GetStreamAsync("templates/PassengerCard.xlsx")))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    byte[] buffer;

                    worksheet.Cells["P13"].Value = passengerCard.NameOfOrganization;
                    worksheet.Cells["P16"].Value = passengerCard.NumberOfAuto;

                    worksheet.Cells["F19"].Value = passengerCard.TypeOfAuto == "0" ? "V" : "";
                    worksheet.Cells["F21"].Value = passengerCard.TypeOfAuto == "1" ? "V" : "";
                    worksheet.Cells["S19"].Value = passengerCard.TypeOfAuto == "2" ? "V" : "";
                    worksheet.Cells["s21"].Value = passengerCard.TypeOfAuto == "3" ? "V" : "";

                    if (passengerCard.EmergencyKit) worksheet.Cells["AB29"].Value = "V";
                    else worksheet.Cells["AE29"].Value = "V";

                    if (passengerCard.MonitoringSystem) worksheet.Cells["AB31"].Value = "V";
                    else worksheet.Cells["AE31"].Value = "V";

                    if (passengerCard.ForeignObjects) worksheet.Cells["AB33"].Value = "V";
                    else worksheet.Cells["AE33"].Value = "V";

                    if (passengerCard.RoutePassport) worksheet.Cells["AB35"].Value = "V";
                    else worksheet.Cells["AE35"].Value = "V";

                    if (passengerCard.BusPassport) worksheet.Cells["AB37"].Value = "V";
                    else worksheet.Cells["AE37"].Value = "V";

                    if (passengerCard.SeatBeltsFastened) worksheet.Cells["AB39"].Value = "V";
                    else worksheet.Cells["AE39"].Value = "V";

                    if (passengerCard.CargoFixed) worksheet.Cells["AB41"].Value = "V";
                    else worksheet.Cells["AE41"].Value = "V";

                    if (passengerCard.SafeLaneChange) worksheet.Cells["AB46"].Value = "V";
                    else worksheet.Cells["AE46"].Value = "V";

                    if (passengerCard.KeepingDistance) worksheet.Cells["AB48"].Value = "V";
                    else worksheet.Cells["AE48"].Value = "V";

                    if (passengerCard.SpeedLimit) worksheet.Cells["AB50"].Value = "V";
                    else worksheet.Cells["AE50"].Value = "V";

                    if (passengerCard.SafeBehavior) worksheet.Cells["AB52"].Value = "V";
                    else worksheet.Cells["AE52"].Value = "V";

                    if (passengerCard.NoCell) worksheet.Cells["AB54"].Value = "V";
                    else worksheet.Cells["AE54"].Value = "V";

                    if (passengerCard.ControlOfAuto) worksheet.Cells["AB56"].Value = "V";
                    else worksheet.Cells["AE56"].Value = "V";

                    if (passengerCard.NotEat) worksheet.Cells["AB58"].Value = "V";
                    else worksheet.Cells["AE58"].Value = "V";

                    if (passengerCard.UnderstandsRoadConditions) worksheet.Cells["AB60"].Value = "V";
                    else worksheet.Cells["AE60"].Value = "V";

                    if (passengerCard.RoadSignRequirements) worksheet.Cells["AB62"].Value = "V";
                    else worksheet.Cells["AE62"].Value = "V";

                    if (passengerCard.TimelyTurnOffTheLights) worksheet.Cells["AB64"].Value = "V";
                    else worksheet.Cells["AE64"].Value = "V";

                    if (passengerCard.AttentionToPedestrians) worksheet.Cells["AB66"].Value = "V";
                    else worksheet.Cells["AE66"].Value = "V";

                    if (passengerCard.GiveWay) worksheet.Cells["AB69"].Value = "V";
                    else worksheet.Cells["AE69"].Value = "V";

                    if (passengerCard.AutoSafelyInReverse) worksheet.Cells["AB71"].Value = "V";
                    else worksheet.Cells["AE71"].Value = "V";

                    if (passengerCard.HandbrakeUsing) worksheet.Cells["AB73"].Value = "V";
                    else worksheet.Cells["AE73"].Value = "V";

                    if (passengerCard.RestRegime) worksheet.Cells["AB75"].Value = "V";
                    else worksheet.Cells["AE75"].Value = "V";

                    if (passengerCard.WorkStopped) worksheet.Cells["BG6"].Value = "V";
                    else worksheet.Cells["BG6"].Value = "";

                    worksheet.Cells["E80"].Value = passengerCard.Night ? "V" : "";
                    worksheet.Cells["E82"].Value = passengerCard.Clear ? "V" : "";
                    worksheet.Cells["E84"].Value = passengerCard.Sun ? "V" : "";
                    worksheet.Cells["E86"].Value = passengerCard.Cloud ? "V" : "";

                    worksheet.Cells["L82"].Value = passengerCard.Rain ? "V" : "";
                    worksheet.Cells["L84"].Value = passengerCard.RainHail ? "V" : "";
                    worksheet.Cells["L86"].Value = passengerCard.Snow ? "V" : "";


                    worksheet.Cells["T80"].Value = passengerCard.Asphalt ? "V" : "";
                    worksheet.Cells["T82"].Value = passengerCard.Ice ? "V" : "";
                    worksheet.Cells["T84"].Value = passengerCard.Gravel ? "V" : "";
                    worksheet.Cells["AA80"].Value = passengerCard.OffRoad ? "V" : "";
                    worksheet.Cells["AA82"].Value = passengerCard.Ground ? "V" : "";
                    worksheet.Cells["AA84"].Value = passengerCard.Dirt ? "V" : "";


                    worksheet.Cells["BA14"].Value = passengerCard.ViolationDetected ? "V" : "";
                    worksheet.Cells["BA16"].Value = passengerCard.WorkStopped ? "V" : "";

                    worksheet.Cells["AL20"].Value = passengerCard.PassengerComment;
                    worksheet.Cells["AL40"].Value = passengerCard.Actions;
                    worksheet.Cells["AL60"].Value = passengerCard.FinalActions;
                    worksheet.Cells["AU71"].Value = passengerCard.Responsible;
                    worksheet.Cells["AU73"].Value = passengerCard.Deadline == null ? "" : ((DateTime)passengerCard.Deadline).ToShortDateString();

                    worksheet.Cells["AU79"].Value = passengerCard.FullName;
                    worksheet.Cells["AU81"].Value = passengerCard.Company;
                    worksheet.Cells["AU83"].Value = passengerCard.Department;
                    worksheet.Cells["AU85"].Value = passengerCard.Position;
                    worksheet.Cells["AU87"].Value = passengerCard.CreationDate.ToShortDateString();

                    buffer = await package.GetAsByteArrayAsync();

                    await JS.InvokeVoidAsync(
                    "saveAsFile",
                    $"{passengerCard.CreationDate.ToShortDateString()}_{passengerCard.CardType}_{passengerCard.ShortName}.xlsx",
                    Convert.ToBase64String(buffer)
                    );

                    //await JS.InvokeVoidAsync(
                    //"sendEmail",
                    //"koleshkov@outlook.com",
                    //$"{passengerCard.CardName}.xlsx",
                    //Convert.ToBase64String(buffer)
                    //);
                }
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}
