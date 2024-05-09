using Microsoft.AspNetCore.Mvc;
using System;

namespace ErrorHandlingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Index()
        {
            try
            {
                // ������������ ������ ����� ������
                // ��� �������, ���������� ���������� ��������� �������
                Random random = new Random();
                int randomNumber = random.Next(1, 4); // ���������� ��������� ����� �� 1 �� 3

                if (randomNumber == 1)
                {
                    throw new Exception("This is a test exception.");
                }
                else if (randomNumber == 2)
                {
                    throw new FileNotFoundException("File not found.");
                }
                else
                {
                    throw new DatabaseException("Database unavailable.");
                }
            }
            catch (Exception ex)
            {
                int errorCode = 500; // �� ��������� ���������� ������ �������

                // ��������� ���������� ����� ����������
                if (ex is FileNotFoundException)
                {
                    errorCode = 404;
                }
                else if (ex is DatabaseException)
                {
                    errorCode = 503;
                }

                // ��������������� �� ��������������� �������� ������
                return View($"Error{errorCode}");

            }
        }
    }

    // ������ ����������������� ���������� ��� ������������
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }
    }
}
