import React from "react";
import Button from "react-bootstrap/Button";

const ButtonUnsuscribe = (props) =>{
    debugger;
    return(
        <Button variant="primary" onClick={props.onClick}> {props.text} </Button>
    )
};

export default ButtonUnsuscribe;