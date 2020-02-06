using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Common;
using Languages.Xml;
using UnityEngine;

namespace Account
{
    public class AccountsManager : Singleton<AccountsManager>
    {
        public bool isLoggedIn;
        public AccountData loggedAccount;

        private string m_FilePath;
        protected override void Awake()
        {
            base.Awake();

            m_FilePath = Application.persistentDataPath + "/accounts.txt";

            // Create file
            if (!File.Exists(m_FilePath))
                File.Create(m_FilePath);
        }

        private void Start()
        {
            // Create admin account
            var adminData = new AccountData()
            {
                firstName = "Hivolve",
                lastName = "Admin",
                country = 4,
                company = "HIVOLVE",
                email = "admin",
                password = "admin"
            };

            if(CanCreateAccount(adminData))
                CreateAccount(adminData);
        }

        public void CreateAccount(AccountData data)
        {
            var accounts = GetAccountsList() ?? new AccountsList()
            {
                data = new List<AccountData>()
            };
            accounts.data.Add(data);

            var json = JsonUtility.ToJson(accounts, true);

            File.WriteAllText(m_FilePath, json);

            Debug.Log("Account created and added");
        }

        public void ResetPassword(LoginData newLoginData)
        {
            if (File.Exists(m_FilePath))
            {
                var accounts = GetAccountsList();

                if (accounts == null)
                {
                    Debug.LogWarning("No Accounts on data base!");
                    return;
                }

                // Verify if email is in database
                foreach (var account in accounts.data)
                {
                    if (newLoginData.email == account.email)
                    {
                        // TODO: CHANGE THIS CUZ ITS NOT UPDATING THE JSON FILE
                        account.password = newLoginData.password;
                    }
                }

                return;
            }

            Debug.Log("No file found");
        }

        public void ResetPassword(string password)
        {
            if(loggedAccount != null)
            {
                foreach (var account in GetAccountsList().data)
                {
                    if (account.email == loggedAccount.email)
                    {
                        // TODO: CHANGE THIS CUZ ITS NOT UPDATING THE JSON FILE
                        account.password = password;
                    }
                }
            }
        }
        public bool AccountIsInDataBase(string email)
        {
            if (File.Exists(m_FilePath))
            {
                var accounts = GetAccountsList();

                if (accounts == null)
                {
                    Debug.Log("Account not in database");
                    return false;
                }

                // Verify if email is in database
                foreach (var account in accounts.data)
                {
                    if (email == account.email)
                        return true;
                }

                Debug.Log("Account not in database");
                return false;
            }

            Debug.Log("No file found");
            return false;
        }
        public bool CanLogin(LoginData data)
        {
            if (File.Exists(m_FilePath))
            {
                var accounts = GetAccountsList();

                if (accounts == null)
                {
                    Debug.Log("No accounts in database");
                    return false;
                }

                // Verify if any email and password matches
                foreach (var account in accounts.data)
                {
                    if (data.email == account.email
                        && data.password == account.password)
                        return true;
                }

                return false;
            }

            Debug.Log("No file found");
            return false;
        }
        public bool CanCreateAccount(AccountData data)
        {
            var accounts = GetAccountsList();

            // No accounts
            if (accounts == null)
                return true;

            foreach (var account in accounts.data)
            {
                if (data.email == account.email)
                    return false;
            }

            return true;
        }
        public CountriesData.Country GetCountryInfo(AccountData account)
        {
            return XmlLoader.Instance.Countries.dataCountries[account.country];
        }
        public AccountData GetAccount(LoginData data)
        {
            if (File.Exists(m_FilePath))
            {
                var accounts = GetAccountsList();

                if (accounts == null)
                {
                    return null;
                }

                // Verify if email is in database
                foreach (var account in accounts.data)
                {
                    if (data.email == account.email)
                        return account;
                }

                return null;
            }

            Debug.Log("No file found");
            return null;
        }
        private AccountsList GetAccountsList()
        {
            // Read file
            var fileData = File.ReadAllText(m_FilePath);
            // Convert json string to AccountsList type
            var accounts = JsonUtility.FromJson<AccountsList>(fileData);

            return accounts;
        }
    }

    [Serializable]
    public class AccountData
    {
        public string firstName;
        public string lastName;
        public int country;
        public string company;
        public string email;
        public string password;
    }
    public class LoginData
    {
        public string email;
        public string password;
    }
    [Serializable]
    public class AccountsList
    {
        public List<AccountData> data;
    }
}