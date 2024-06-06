package com.example.uuser;

import org.apache.catalina.User;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/users")
public class UUserController {
    @GetMapping
    public String getUser() {
        return "Hello, World!";
    }
    @PostMapping
    public String setUser(@RequestBody User user) {
        return "Hello, World!";
    }
    @DeleteMapping String deleteUser(@RequestBody User user){return "Hello, World!";}
    @PutMapping String updateUser(@RequestBody User user){return "Hello, World!";}
}
