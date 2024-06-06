java 21
SDK 21.0.3
Spring boot 3.3.0

//build project
mvc clean install
(ყველა პროექტი დაბილდულია ანუ .jar ფაილები შექმნილია და ეს შეიძლება არ დაგჭირდეთ)

//run application
mvn spring-boot:run

//terminate application
kill <PID>
   or
kill -9 <PID>

PID რიცხვია და წერია აპლიკაციას, რომ გაუშვებთ INFO-ს მერე აი მაგალითად <2024-06-05T22:20:29.897+04:00  INFO 25362 --- [Payment] [           main] com.example.payment.PaymentApplication   : Started PaymentApplication in 1.731 seconds (process running for 2.082)> აქ 25362 არის PID
აპლიკაციის გასაჩერებლად ეს kill ქომანდი ახალ ტერმინალში უნდა ჩაწეროთ



