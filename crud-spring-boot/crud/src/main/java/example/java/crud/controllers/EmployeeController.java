package example.java.crud.controllers;

import example.java.crud.dtos.EmployeeDto;
import example.java.crud.services.EmployeeService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/employees")
@RequiredArgsConstructor
public class EmployeeController {

    @Autowired
    private final EmployeeService employeeService;

    @PostMapping("create")
    public ResponseEntity<?> create(@RequestBody EmployeeDto employeeDto) {
        EmployeeDto savedEmployee = employeeService.create(employeeDto);
        return new ResponseEntity<>(savedEmployee, HttpStatus.CREATED);
    }

    @GetMapping("get/{id}")
    public ResponseEntity<?> getById(@PathVariable("id") long id) {
        EmployeeDto foundEmployee = employeeService.read(id);
        return new ResponseEntity<>(foundEmployee, HttpStatus.OK);
    }

    @GetMapping("get-all")
    public ResponseEntity<?> getAll() {
        List<EmployeeDto> foundEmployees = employeeService.readAll();
        return new ResponseEntity<>(foundEmployees, HttpStatus.OK);
    }

    @PutMapping("update")
    public ResponseEntity<?> update(@RequestBody EmployeeDto employeeDto) {
        EmployeeDto updatedEmployee = employeeService.update(employeeDto);
        return new ResponseEntity<>(updatedEmployee, HttpStatus.OK);
    }

    @DeleteMapping("delete/{id}")
    public ResponseEntity<?> delete(@PathVariable("id") long id) {
        employeeService.delete(id);
        return new ResponseEntity<>(HttpStatus.ACCEPTED);
    }
}
