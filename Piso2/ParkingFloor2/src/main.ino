#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ArduinoJson.h>
#include <Carro.h>

const char *ssid = "MPS";
const char *password = "Siemenss71500";
bool state = false;
String send;
WiFiServer server(80);
Carro cars[8];
String header;
int x;
void setup()
{
  Serial.begin(9600);
  Serial.print("Conectando.. ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  cars[0] = Carro("AJK1", 1, 1, "Sutanito", 2, false);
  cars[1] = Carro("AJK1", 2, 2, "Sutanito", 2, false);
  cars[2] = Carro("AJK1", 3, 3, "Sutanito", 2, false);
  cars[3] = Carro("AJK1", 4, 4, "Sutanito", 2, false);
  cars[4] = Carro("AJK1", 5, 5, "Sutanito", 2, false);
  cars[5] = Carro("AJK1", 6, 6, "Sutanito", 2, false);
  cars[6] = Carro("AJK1", 7, 7, "Sutanito", 2, false);
  cars[7] = Carro("AJK1", 8, 8, "Sutanito", 2, false);
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    Serial.print(".");
    //String licensePlate, int placeID, int carID, String owner, int floorID, bool state

  }
  // Print local IP address and start web server
  Serial.println("");
  Serial.println("WiFi conectado...");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  server.begin();

  pinMode(0, INPUT);
  pinMode(1, INPUT);
  pinMode(2, INPUT);
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  pinMode(7, INPUT);
}
void loop()
{
  StaticJsonDocument<200> doc;
  for (size_t i = 0; i < 8; i++)
  {
    state = digitalRead(i);
    if (state)
    {
      cars[i].setOwner("Whatever");
      cars[i].setLicensePlate("asdf123");
      cars[i].setState(true);
    }
    else
    {
      cars[i].setOwner("N/A");
      cars[i].setLicensePlate("N/A");
      cars[i].setState(false);
    }

    /* code */
  }

  if (WiFi.status() == WL_CONNECTED)
  {

    HTTPClient http;

    http.begin("http:parkingutadeo.azuewebsites.net/api/Send");
    http.addHeader("Content-Type", "text/application/json");

    for (size_t i = 0; i < 8; i++)
    {

      /* code */

      doc["carID"] = cars[i].getCarID();
      doc["placeID"]=cars[i].getPlaceID();
      doc["floorID"]=cars[i].getFloorID();
      doc["owner"]=cars[i].getOwner();
      doc["licensePlate"]=cars[i].getLicensePlate();
      serializeJson(doc, send);
    }

    int httpResponseCode = http.PUT(send);

    if (httpResponseCode > 0)
    {

      String response = http.getString();

      Serial.println(httpResponseCode);
      Serial.println(response);
    }
    else
    {

      Serial.print("Error al enviar la solicitud PUT ");
      Serial.println(httpResponseCode);
    }

    http.end();
  }
  else
  {
    Serial.println("Error en la conexión WiFi");
  }
}



