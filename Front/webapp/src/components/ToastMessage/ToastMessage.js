import React from "react";
import Toast from "react-bootstrap/Toast";

const ToastMessage = props => {

  return (
    <div
      aria-live="polite"
      aria-atomic="true"
      style={{
        minHeight: "100px"
      }}
    >
      <Toast className="bg-dark text-white" onClose={props.close} show={props.show}
        style={{
          position: "absolute",
          width: "100%",
          left: "2.5%",
          bottom: "15%"
        }}
        delay={3000} autohide>
        <Toast.Body>{props.info}</Toast.Body>
      </Toast>
    </div>
  );
};

export default ToastMessage;
