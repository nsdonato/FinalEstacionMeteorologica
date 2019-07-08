import React from "react";
import Toast from "react-bootstrap/Toast";

const ToastMessage = props => {

  return (
    <div
      aria-live="polite"
      aria-atomic="true"
      style={{
        position: "relative",
        minHeight: "100px"
      }}
    >
      <Toast onClose={props.close} show={props.show}
        style={{
          position: "absolute",
          top: 0,
          right: 0
        }}
        delay={3000} autohide >
        <Toast.Header>
        </Toast.Header>
        <Toast.Body>{props.info}</Toast.Body>
      </Toast>
    </div>
  );
};

export default ToastMessage;
