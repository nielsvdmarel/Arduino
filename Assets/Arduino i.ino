int joyPin1 = 0;
int joyPin2 = 1;
int value1 = 0;
int value2 = 0;
void setup()
{
 Serial.begin (19200);
}
int treatValue(int data){
// return (data * 9 / 1024) + 48;
return (data);
}
void loop()
{
 value1 = analogRead(joyPin1);
 delay(100);
 value2 = analogRead(joyPin2);
 Serial.print(treatValue(value1));
 Serial.print(",");
 Serial.println(treatValue(value2));
}