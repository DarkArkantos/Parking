#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ArduinoJson.h>
 
const char* ssid     = "MPS";
const char* password = "Siemenss71500";
WiFiServer server(80);

String header;
 int x;
void setup() {
  Serial.begin(9600);
  Serial.print("Conectando.. ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  // Print local IP address and start web server
  Serial.println("");
  Serial.println("WiFi conectado...");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  server.begin();

  pinMode(0,INPUT);
  pinMode(1,INPUT);
  pinMode(2,INPUT);
  pinMode(3,INPUT);
  pinMode(4,INPUT);
  pinMode(5,INPUT);
  pinMode(6,INPUT);
  pinMode(7,INPUT);

}



Carro carro0 = Carro("AJK1", digitalRead(0) ,8);
Carro carro1 = Carro("AJK1", digitalRead(1),9);
Carro carro2 = Carro("AJK1", digitalRead(2),10);
Carro carro3 = Carro("AJK1", digitalRead(3),11);
Carro carro4 = Carro("AJK1", digitalRead(4),12);
Carro carro5 = Carro("AJK1", digitalRead(5),13);
Carro carro6 = Carro("AJK1", digitalRead(6),14);
Carro carro7 = Carro("AJK1", digitalRead(7),15);


 
class Carro{
  private:
    String licensePlate;
    boolean state;
    int puesto;

  public:

     void SetlicensePlate( String a){
        licensePlate= a;
    }

   String GetlisencePlate(){
      return (licensePlate);
    }

    void Setstate(boolean o){
      state=o;
    }
    
    boolean Getstate(){
      return(state);
    }

    void Setpuesto(int p){
      puesto=p;
    }

    int Getpuesto(){
      return(puesto);
    }
    Carro(String licensePlate, boolean state, int puesto){
        licensePlate=licensePlate;
         state=state;
         puesto=puesto;
        
    }
   
};



void loop() {
  carro0.Setstate = digitalRead(0);
  carro1.Setstate = digitalRead(1);
  carro2.Setstate = digitalRead(2);
  carro3.Setstate = digitalRead(3);
  carro4.Setstate = digitalRead(4);
  carro5.Setstate = digitalRead(5);
  carro6.Setstate = digitalRead(6);
  carro7.Setstate = digitalRead(7);
  

 
 if(WiFi.status()== WL_CONNECTED){
 
   HTTPClient http;   
 
   http.begin("http:parkingutadeo.azuewebsites.net/api/Send");
   http.addHeader("Content-Type", "text/application/json");            
 
   int httpResponseCode = http.POST("POSTING enviado desde ESP32");   
 
   if(httpResponseCode>0){
 
    String response = http.getString();   
 
    Serial.println(httpResponseCode);
    Serial.println(response);          
 
   }else{
 
    Serial.print("Error al enviar la solicitud POST ");
    Serial.println(httpResponseCode);
 
   }
 
   http.end();
 
 }else{
    Serial.println("Error en la conexión WiFi");
 }
 
  delay(10000);

  // compute the required size
const size_t CAPACITY = JSON_ARRAY_SIZE(1);

// allocate the memory for the document
StaticJsonDocument<CAPACITY> doc;

// create an empty array
JsonArray array = doc.to<JsonArray>();

// add some values

array.add("Carro");

// serialize the array and send the result to Serial
serializeJson(doc, Serial);

}



 