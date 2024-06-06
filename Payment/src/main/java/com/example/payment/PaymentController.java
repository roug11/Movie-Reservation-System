package com.example.payment;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class PaymentController {
    @GetMapping
    public String sayHello() {
        return "Hello, World!";
    }
}
