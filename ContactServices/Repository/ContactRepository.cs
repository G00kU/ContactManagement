using ContactServices.Modal;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ContactServices.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connectionString;
        public ContactRepository(IConfiguration config)
        {
            _connectionString =config.GetConnectionString("DefaultConnection");

        }

        public  List<ContactDTO> GetAllContact()
        {
            List <ContactDTO> contacts = new List < ContactDTO >();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("dbo.usp_GetAllContacts", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader( );
                    while (reader.Read()) {
                        ContactDTO contact = new ContactDTO
                        {
                            ContactId = reader.GetInt32(reader.GetOrdinal("ContactId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                            State = reader.IsDBNull(reader.GetOrdinal("State")) ? null : reader.GetString(reader.GetOrdinal("State")),
                            Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : reader.GetString(reader.GetOrdinal("Country")),
                            PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : reader.GetString(reader.GetOrdinal("PostalCode")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            ModifiedAt = reader.GetDateTime(reader.GetOrdinal("ModifiedAt"))
                        };
                        contacts.Add(contact);

                    }
                }
                return contacts;
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        public ContactDTO GetContactById(int contactId)
        {
            ContactDTO contact= null;
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("dbo.usp_GetContactById", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContactId", contactId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contact = new ContactDTO()
                        {
                            ContactId = reader.GetInt32(reader.GetOrdinal("ContactId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                            State = reader.IsDBNull(reader.GetOrdinal("State")) ? null : reader.GetString(reader.GetOrdinal("State")),
                            Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : reader.GetString(reader.GetOrdinal("Country")),
                            PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : reader.GetString(reader.GetOrdinal("PostalCode")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            ModifiedAt = reader.GetDateTime(reader.GetOrdinal("ModifiedAt"))
                        };

                    }
                }
                return contact;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int InsertorUpdateContact(ContactDTO dto)
        {
            int contactId = 0;
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("dbo.usp_InsertorUpdateContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContactId", dto.ContactId);
                    command.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    command.Parameters.AddWithValue("@LastName", dto.LastName);
                    command.Parameters.AddWithValue("@Email", dto.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", dto.PhoneNumber ?? (object)DBNull.Value); 
                    command.Parameters.AddWithValue("@Address", dto.Address ?? (object)DBNull.Value); 
                    command.Parameters.AddWithValue("@City", dto.City ?? (object)DBNull.Value); 
                    command.Parameters.AddWithValue("@State", dto.State ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", dto.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PostalCode", dto.PostalCode ?? (object)DBNull.Value);
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        contactId = id;
                    }
                   
                }

            }
            catch (Exception)
            {
                throw;
            }
            return contactId;
        }

        public int DeleteContact(int ContactId)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_DeleteContact", connection);
                    command.Parameters.AddWithValue("@ContactId", ContactId);
                    rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

    }

}
