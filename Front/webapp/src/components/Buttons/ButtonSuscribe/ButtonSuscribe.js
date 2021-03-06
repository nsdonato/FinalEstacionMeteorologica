import React from "react";
import Button from "react-bootstrap/Button";

const ButtonSuscribe = (props) =>{
    return(
        <Button variant="primary" onClick={props.onClick}> {props.text} </Button>
    )
};

export default ButtonSuscribe;