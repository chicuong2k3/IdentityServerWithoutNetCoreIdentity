// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using IdentityModel;
using System.Security.Claims;
using Duende.IdentityServer.Test;

namespace IdentityProvider.Pages;

public static class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "cuong",
                    Password = "cuong",
                    Claims =
                    {
                        new Claim("role", "Admin"),
                        new Claim(JwtClaimTypes.Name, "Nguyễn Cường"),
                        new Claim(JwtClaimTypes.GivenName, "Cường"),
                        new Claim(JwtClaimTypes.FamilyName, "Nguyễn"),
                        new Claim("country", "cn")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "tuan",
                    Password = "tuan",
                    Claims =
                    {
                        new Claim("role", "Customer"),
                        new Claim(JwtClaimTypes.Name, "Quốc Tuấn"),
                        new Claim(JwtClaimTypes.GivenName, "Tuấn"),
                        new Claim(JwtClaimTypes.FamilyName, "Quốc"),
                        new Claim("country", "vn")
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "dung",
                    Password = "dung",
                    Claims =
                    {
                        new Claim("role", "Admin"),
                        new Claim(JwtClaimTypes.Name, "Tấn Dũng"),
                        new Claim(JwtClaimTypes.GivenName, "Dũng"),
                        new Claim(JwtClaimTypes.FamilyName, "Tấn"),
                        new Claim("country", "vn")
                    }
                }
            };
        }
    }
}