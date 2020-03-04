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

        public void SendKeyUpLoad(IWebDriver driver, string value, string NameElement)
        {
            //IWebDriver driver;
            //IWebElement element;
            //String value;

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + value + "';", driver.FindElement(By.XPath(NameElement)));
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

        // ESPERAR A QUE EL ELEMENTO SEA VISIBLE
        public void WaitForElementPresent(IWebDriver driver, string TypeElement, string NameElement)
        {
            switch (TypeElement)
            {
                case "XPath":
                    new WebDriverWait(driver, TimeSpan.FromSeconds(9)).Until(ExpectedConditions.ElementExists(By.XPath(NameElement)));
                    break;

                case "Id":
                    new WebDriverWait(driver, TimeSpan.FromSeconds(9)).Until(ExpectedConditions.ElementExists(By.Id(NameElement)));
                    break;

                case "Name":
                    new WebDriverWait(driver, TimeSpan.FromSeconds(9)).Until(ExpectedConditions.ElementExists(By.Name(NameElement)));
                    break;
            }
        }

        public void Loading(IWebElement elemento)
        {
            while (!elemento.Displayed)
            {
                Thread.Sleep((int)TimerSleepType.sleepTimerFast);
            }
        }

        public void Click(IWebDriver driver, string TypeElement, string NameElement)
        {
            switch (TypeElement)
            {
                case "XPath":
                    var waitXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementXPath = waitXPath.Until(x => x.FindElement(By.XPath(NameElement)));
                    if (myElementXPath.Displayed && myElementXPath.Enabled)
                    {
                        Thread.Sleep(900);
                        driver.FindElement(By.XPath(NameElement)).Click();
                    }

                break;
                case "Id":
                    var waitId = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementId = waitId.Until(x => x.FindElement(By.Id(NameElement)));
                    if (myElementId.Displayed && myElementId.Enabled)
                    {
                        Thread.Sleep(900);
                        driver.FindElement(By.Id(NameElement)).Click();
                    }

                break;
                case "Name":
                    var waitName = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementName = waitName.Until(x => x.FindElement(By.Name(NameElement)));
                    if (myElementName.Displayed && myElementName.Enabled)
                    {
                        Thread.Sleep(900);
                        driver.FindElement(By.Name(NameElement)).Click();
                    }

                    break;
            }


        }

        public void ClickWithOption(IWebDriver driver, string NameElement, string Opcion)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            var myElement = wait.Until(x => x.FindElement(By.XPath(NameElement + Opcion + "')]")));
            if (myElement.Displayed && myElement.Enabled)
            {
                Thread.Sleep(900);
                driver.FindElement(By.XPath(NameElement + Opcion + "')]")).Click();
            }

        }

        public void SendText(IWebDriver driver, string TypeElement, string NameElement, string Opcion)
        {
            switch (TypeElement)
            {
                case "XPath":
                    var waitXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementXPath = waitXPath.Until(x => x.FindElement(By.XPath(NameElement)));
                    if (myElementXPath.Displayed && myElementXPath.Enabled)
                    {
                        Thread.Sleep(900);
                        driver.FindElement(By.XPath(NameElement)).Clear();
                        driver.FindElement(By.XPath(NameElement)).SendKeys(Opcion);
                    }
                    break;

                case "Id":
                    var waitId = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementId = waitId.Until(x => x.FindElement(By.Id(NameElement)));
                    if (myElementId.Displayed && myElementId.Enabled)
                    {
                        Thread.Sleep(900);
                        driver.FindElement(By.Id(NameElement)).Clear();
                        driver.FindElement(By.Id(NameElement)).SendKeys(Opcion);
                    }
                    break;

                case "Name":
                    var waitName = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementName = waitName.Until(x => x.FindElement(By.Name(NameElement)));
                    if (myElementName.Displayed && myElementName.Enabled)
                    {
                        Thread.Sleep(900);
                        driver.FindElement(By.Name(NameElement)).Clear();
                        driver.FindElement(By.Name(NameElement)).SendKeys(Opcion);
                    }
                    break;
            }
        }

        public void SendTextWithOption(IWebDriver driver, string NameElement, string Option)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            var myElement = wait.Until(x => x.FindElement(By.XPath(NameElement + Option + "')]")));
            if (myElement.Displayed && myElement.Enabled)
            {
                Thread.Sleep(900);
                driver.FindElement(By.XPath(NameElement + Option + "')]")).Clear();
                driver.FindElement(By.XPath(NameElement + Option + "')]")).SendKeys(Option);
            }
        }

        // SELECCIONAR CAMPO "LISTA" POR TEXTO
        public void SelectOpcionByText(IWebDriver driver, string TypeElement, string NameElement, string Option)
        {
            switch (TypeElement)
            {
                case "XPath":
                    var waitXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementXPath = waitXPath.Until(x => x.FindElement(By.XPath(NameElement)));
                    if (myElementXPath.Displayed && myElementXPath.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.XPath(NameElement))).SelectByText(Option);
                    }
                    break;

                case "Id":
                    var waitId = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementId = waitId.Until(x => x.FindElement(By.Id(NameElement)));
                    if (myElementId.Displayed && myElementId.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.Id(NameElement))).SelectByText(Option);
                    }
                    break;

                case "Name":
                    var waitName = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementName = waitName.Until(x => x.FindElement(By.Name(NameElement)));
                    if (myElementName.Displayed && myElementName.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.Name(NameElement))).SelectByText(Option);
                    }
                    break;
            }
        }

        // SELECCIONAR CAMPO "LISTA" POR VALOR
        public void SelectOpcionByValue(IWebDriver driver, string TypeElement, string NameElement, string Option)
        {
            switch (TypeElement)
            {
                case "XPath":
                    var waitXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementXPath = waitXPath.Until(x => x.FindElement(By.XPath(NameElement)));
                    if (myElementXPath.Displayed && myElementXPath.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.XPath(NameElement))).SelectByValue(Option);
                    }
                    break;

                case "Id":
                    var waitId = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementId = waitId.Until(x => x.FindElement(By.Id(NameElement)));
                    if (myElementId.Displayed && myElementId.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.Id(NameElement))).SelectByValue(Option);
                    }
                    break;

                case "Name":
                    var waitName = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementName = waitName.Until(x => x.FindElement(By.Name(NameElement)));
                    if (myElementName.Displayed && myElementName.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.Name(NameElement))).SelectByValue(Option);
                    }
                    break;
            }
        }

        // SELECCIONAR CAMPO "LISTA" POR INDEX
        public void SelectOpcionByValue(IWebDriver driver, string TypeElement, string NameElement, int Option)
        {
            switch (TypeElement)
            {
                case "XPath":
                    var waitXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementXPath = waitXPath.Until(x => x.FindElement(By.XPath(NameElement)));
                    if (myElementXPath.Displayed && myElementXPath.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.XPath(NameElement))).SelectByIndex(Option);
                    }
                    break;

                case "Id":
                    var waitId = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementId = waitId.Until(x => x.FindElement(By.Id(NameElement)));
                    if (myElementId.Displayed && myElementId.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.Id(NameElement))).SelectByIndex(Option);
                    }
                    break;

                case "Name":
                    var waitName = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                    var myElementName = waitName.Until(x => x.FindElement(By.Name(NameElement)));
                    if (myElementName.Displayed && myElementName.Enabled)
                    {
                        Thread.Sleep(900);
                        new SelectElement(driver.FindElement(By.Name(NameElement))).SelectByIndex(Option);
                    }
                    break;
            }
        }

        // VALIDAR EXISTENCIA DE UN ELEMENTO
        //public bool ValidationElementEnabled(IWebDriver driver, string TypeElement, string NameElement)
        //{
        //    bool valElemento;
        //    bool resultado;

        //    switch (TypeElement)
        //    {
        //        case "XPath":
        //            var waitXPath = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        //            var myElementXPath = waitXPath.Until(x => x.FindElement(By.XPath(NameElement)));
        //            try
        //            {
        //                valElemento = driver.FindElement(By.XPath(NameElement)).Displayed;
        //                valElemento = driver.FindElement(By.XPath(NameElement)).Enabled;
        //            }
        //            catch
        //            {
        //                valElemento = false;
        //            }
        //            if (valElemento == true)
        //            {
        //                resultado = true;
        //            }
        //            else
        //            {
        //                resultado = false;
        //            }
        //            return resultado;
        //            break;
                //case "Id":
                //    var waitId = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                //    var myElementId = waitId.Until(x => x.FindElement(By.Id(NameElement)));
                //    if (myElementId.Displayed && myElementId.Enabled)
                //    {
                //        Thread.Sleep(900);
                //        Visible = true;
                //    }
                //    else
                //    {
                //        Visible = false;
                //    }

                //    break;
                //case "Name":
                //    var waitName = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                //    var myElementName = waitName.Until(x => x.FindElement(By.Name(NameElement)));
                //    if (myElementName.Displayed && myElementName.Enabled)
                //    {
                //        Thread.Sleep(900);
                //        Visible = true;
                //    }
                //    else
                //    {
                //        Visible = false;
                //    }

                //    break;

            //}

        //}
    }
} // FIN DEL PUBLIC CLASS
