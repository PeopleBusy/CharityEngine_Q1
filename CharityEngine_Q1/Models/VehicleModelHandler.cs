using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CharityEngine_Q1.Models
{
    public class VehicleModelHandler
    {
        private SqlConnection con;
        private void connection()
        {
            //Retrieving connection string from Web.config file
            string constring = ConfigurationManager.ConnectionStrings["appartmentconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** UPDATE EXISTING VEHICLE OR ADD NEW VEHICLE *********************
        public bool AddOrUpdateVehicle(VehicleModel vehicleModel, int registrationNumber = 0)
        {
            connection();
            string sqlCmd = String.Empty;
            if (registrationNumber == 0)
                sqlCmd = @"INSERT INTO vehicle(owner_name, owner_phone_number, owner_unit_number, owner_appartement_number,
                                    vehicle_make, vehicle_model, vehicle_color, registration_date) 
                            VALUES(@owner_name, @owner_phone_number, @owner_unit_number, @owner_appartement_number, 
                                            @vehicle_make, @vehicle_model, @vehicle_color, @registration_date)";
            else
                sqlCmd = $@"UPDATE vehicle SET owner_name = @owner_name, owner_phone_number = @owner_phone_number, owner_unit_number = @owner_unit_number, 
                    owner_appartement_number = @owner_appartement_number, vehicle_make =  @vehicle_make, 
                    vehicle_model = @vehicle_model, vehicle_color = @vehicle_color, registration_date = @registration_date
                    WHERE vehicle_registration_number = {registrationNumber}";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCmd;

            cmd.Parameters.AddWithValue("@owner_name", vehicleModel.OwnerName);
            cmd.Parameters.AddWithValue("@owner_phone_number", vehicleModel.OwnerPhoneNumber);
            cmd.Parameters.AddWithValue("@owner_unit_number", vehicleModel.OwnerUnitNumber);
            cmd.Parameters.AddWithValue("@owner_appartement_number", vehicleModel.OwnerAppartementNumber);
            cmd.Parameters.AddWithValue("@vehicle_make", vehicleModel.VehiceMake);
            cmd.Parameters.AddWithValue("@vehicle_model", vehicleModel.VehiceModel);
            cmd.Parameters.AddWithValue("@vehicle_color", vehicleModel.VehiceColor);
            cmd.Parameters.AddWithValue("@registration_date", vehicleModel.RegistrationDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // **************** SEARCH FOR A VEHICULE OR FETCH ALL VEHICLES *********************
        public List<VehicleModel> GetVehicles(int registrationNumber = 0)
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();
            connection();

            string sqlCmd = (registrationNumber == 0) ? $"SELECT * FROM vehicle WHERE vehicle_registration_number = {registrationNumber}" : "SELECT * FROM vehicle";

            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            var vehicle = new VehicleModel();
            while (rdr.Read())
            {
                vehicle.VehiceRegistrationNumber = Convert.ToInt32(rdr["Id"]);
                vehicle.OwnerName = rdr["owner_name"].ToString();
                vehicle.OwnerPhoneNumber = Convert.ToInt32(rdr["owner_phone_number"]);
                vehicle.OwnerUnitNumber = rdr["owner_unit_number"].ToString();
                vehicle.OwnerAppartementNumber = rdr["owner_appartement_number"].ToString();
                vehicle.VehiceMake = rdr["vehicle_make"].ToString();
                vehicle.VehiceModel = rdr["vehicle_model"].ToString();
                vehicle.VehiceColor = rdr["vehicle_color"].ToString();
                vehicle.RegistrationDate = DateTime.Parse(rdr["registration_date"].ToString());
                vehicles.Add(vehicle);
            }

            con.Close();
            return vehicles;
        }
    }
}