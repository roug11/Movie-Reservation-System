package com.example.uuser;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UUserController {
    @GetMapping
    public String sayHello() {
        return "Hello, World!";
    }
}
