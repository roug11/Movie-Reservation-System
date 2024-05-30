package com.example.usertheatrepayment;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class UserTheatrePaymentApplication {

    public static void main(String[] args) {
        payment t = new payment(5);
        t.test();
        SpringApplication.run(UserTheatrePaymentApplication.class, args);
    }
}
