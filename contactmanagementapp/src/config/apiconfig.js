const baseUrl = "https://localhost:7242/api/";

export const loginMethod = `${baseUrl}Auth/login`;

export const getAllContacts = `${baseUrl}Contact/GetAllContacts`;
export const getContactById = `${baseUrl}Contact/GetContactById`;
export const insertOrUpdateContact = `${baseUrl}Contact/InsertorUpdateContact`;
export const deleteContactById = `${baseUrl}Contact/DeleteContact`;
