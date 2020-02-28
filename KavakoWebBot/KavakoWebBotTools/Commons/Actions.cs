using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ChatBotSuitTools.Commons
{
    public class Actions
    {
        IWebDriver driver;
        IList<IWebElement> lstDiasCalendario = null;

        public enum TimerSleepType
        {
            sleepTimerMinimum = 1500,
            sleepTimerFast = 2500,
            sleepTimerMedium = 3500,
            sleepTimerSlow = 5000,
            sleepTimerLoad = 6500
        };

        public Document CrearReporte(string pathLogo, Document doc, FileStream streaming, string casoPrueba)
        {
            Document documento = new Document(PageSize.A4, 20, 20, 25, 25);
            PdfWriter.GetInstance(documento, streaming);
            Image logoEdenred = Image.GetInstance(pathLogo);
            Font headerFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN.ToString(), 12, Font.BOLD, BaseColor.BLUE);
            Paragraph texto = new Paragraph();
            PdfPTable table = new PdfPTable(1);

            documento.Open();
            logoEdenred.ScalePercent(80);

            PdfPCell cell = new PdfPCell(logoEdenred);

            cell.Colspan = 5;
            cell.Border = 0;
            cell.BorderColor = BaseColor.WHITE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            documento.NewPage();
            documento.Add(table);
            texto.Add(new Phrase(casoPrueba, headerFont));
            texto.Alignment = Element.ALIGN_JUSTIFIED;
            documento.Add(texto);
            documento.Add(new Paragraph("\n"));

            return documento;
        }

        public void ObtenerEvidenciaCaso(IWebDriver driver, Document doc, string EncabezadoEvidencia, string casoPrueba)
        {
            Font headerFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN.ToString(), 10, Font.BOLD, BaseColor.DARK_GRAY);
            Paragraph texto = new Paragraph();
            PdfPTable table = new PdfPTable(1);
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile("imagenCaso" + casoPrueba + ".png", ScreenshotImageFormat.Png);
            Image foto = Image.GetInstance("imagenCaso" + casoPrueba + ".png");

            texto.Add(new Phrase(EncabezadoEvidencia.ToUpper(), headerFont));
            texto.Alignment = Element.ALIGN_JUSTIFIED;
            foto.ScalePercent(30);

            PdfPCell cell = new PdfPCell(foto);

            cell.Colspan = 5;
            cell.Border = 0;
            cell.BorderColor = BaseColor.WHITE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            doc.Add(texto);
            doc.Add(new Paragraph("\n"));
            doc.Add(table);

            Thread.Sleep(1000);
        }

        public void UpLoading(IWebElement driver, string path)
        {
            const string removeAttribute = @"document.getElementByXpath('browseButton').removeAttribute('disabled');";
            ((IJavaScriptExecutor)driver).ExecuteScript(removeAttribute);
            driver.Clear();
            driver.SendKeys(path);
        }

        public void ArchivoFileUploader(IWebDriver driver, string filePath)
        {
            String script = "document.getElementById('filetravelFile').value='" + filePath + "';";

            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        
        public void LimpiarInput(IWebElement elemento)
        {
            elemento.Clear();
        }

        public void LimpiarYLLenarInput(IWebElement input, string texto)
        {
            LimpiarInput(input);
            input.SendKeys(texto);

            Thread.Sleep((int)TimerSleepType.sleepTimerFast);
        }

        public void LLenarInput(IWebElement input, string texto)
        {
            input.SendKeys(texto);

            Thread.Sleep((int)TimerSleepType.sleepTimerFast);
        }

        public void TerminarProceso(IWebDriver driver, Document doc)
        {
            doc.Close();
            doc.Dispose();
            LogOff(driver);
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }

        public void CerrarDriver(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }

        public void CerrarDocumento(Document doc)
        {
            doc.Close();
            doc.Dispose();
        }

        public void LogOff(IWebDriver driver)
        {
            // ELEMENTOS DE LOG-OFF 01
            IWebElement elementoIconoUsuario = driver.FindElement(By.XPath("//img[@alt='user']"));
            elementoIconoUsuario.Click();
            Thread.Sleep(1000);

            // ELEMENTOS DE LOG-OFF 02
            IWebElement elementoLogOut = driver.FindElement(By.LinkText("power_settings_new Logout"));
            elementoLogOut.Click();
            Thread.Sleep(2000);
        }

        // REALIZA UN SCROLL
        public void ScrollTo(IWebDriver driver, int xPosition, int yPosition)
        {
            IJavaScriptExecutor je = driver as IJavaScriptExecutor;

            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            je.ExecuteScript(js);
        }

        // REALIZA UN SCROLL
        public void ScrollTo(IWebDriver driver, IWebElement elemento)
        {
            IJavaScriptExecutor je = driver as IJavaScriptExecutor;
            string id = elemento.GetAttribute("id");

            var js = String.Format("document.getElementById('" + id + "').focus();");
            je.ExecuteScript(js);
        }

        // REALIZA UN SCROLL A ELEMENTO
        public void ScrollToElement(IWebDriver driver, IWebElement elemento)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", elemento);

        }

        //public void Loading(IWebDriver driver, int timeMiliseconds)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeMiliseconds));
        //    driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromMilliseconds(timeMiliseconds));
        //    Thread.Sleep(timeMiliseconds);

        //    //new WebDriverWait(driver, TimeSpan.FromSeconds(sleepTimerSlow)).Until(ExpectedConditions.ElementExists(By.XPath("//li[1]/a/div/div/div/div/div")));
        //}

        public void Loading(IWebElement elemento)
        {
            while (!elemento.Displayed)
            {
                Thread.Sleep((int)TimerSleepType.sleepTimerFast);
            }
        }

        //public void Loading(IWebDriver driver)
        //{
        //    IWebElement backGroundProcess = driver.FindElement(By.Id("BackProcess"));
        //    IWebElement backGroundProcessImage = driver.FindElement(By.Id("BackProcessImg"));

        //    while (backGroundProcess.Displayed || backGroundProcessImage.Displayed)
        //    {
        //        Thread.Sleep((int)TimerSleepType.sleepTimerFast);
        //    }
        //}
    }
} // FIN DEL PUBLIC CLASS
